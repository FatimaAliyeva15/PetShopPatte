using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using PetShopPatte_Business.DTOs.AccountDTOs;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Business.Services.Concretes;
using PetShopPatte_Core.Entities.UserModel;
using static System.Net.WebRequestMethods;

namespace PetShop_Patte.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAccountService _accountService;
        private readonly ISendMessageService _sendService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAccountService accountService, ISendMessageService sendService, LinkGenerator linkGenerator, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accountService = accountService;
            _sendService = sendService;
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<IActionResult> CreateRoles()
        {
            await _accountService.CreateRoleAsync();
            return RedirectToAction("Index", "Home");
        }

        //[HttpGet]
        //public IActionResult CheckEmailAddress()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> CheckEmailAddress(string emailAddress)
        //{
        //    if (string.IsNullOrEmpty(emailAddress))
        //    {
        //        ModelState.AddModelError(string.Empty, "Email address is required.");
        //        return View();
        //    }

        //    var token = await _sendService.GenerateTokenAsync(emailAddress);
        //    if (token != null)
        //    {
        //        var confirmationUrl = _linkGenerator.GetUriByAction(_httpContextAccessor.HttpContext, action: "ConfirmEmailAddress", controller: "Account",
        //            values: new { email = emailAddress, token });

        //        await _sendService.SendMessageAsync(emailAddress, confirmationUrl);
        //        ViewBag.Message = "Confirmation email has been sent. Please check your email.";
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(string.Empty, "Failed to generate token.");
        //    }

        //    return View();
        //}

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            RegisterDTOValidation validator = new RegisterDTOValidation();
            var validationResult = await validator.ValidateAsync(registerDTO);
            var emailAddress = registerDTO.Email;

            if (!validationResult.IsValid)
            {
                ModelState.Clear();

                validationResult.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(registerDTO);
            }

            await _accountService.RegisterAsync(registerDTO);
            Response.Cookies.Append("ConfirmationLinkSent", "true", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTimeOffset.UtcNow.AddMinutes(30)
            });

            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //[HttpGet]
        //public async Task<IActionResult> ConfirmEmailAddress(string email, string token)
        //{
        //    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
        //    {
        //        return BadRequest("Email or token is missing.");
        //    }

        //    var result = await _sendService.ConfirmEmailAddress(email, token);
        //    if (result.Succeeded)
        //    {
        //        ViewBag.Message = "Email confirmed successfully.";
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Failed to confirm email.";
        //    }

        //    return View();
        //}


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/Admin");
            }
            else
            {
                await _accountService.CreateRoleAsync();
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            //LoginDTOValidation validations = new LoginDTOValidation(_userManager, _signInManager);
            //var validationResult = await validations.ValidateAsync(loginDTO);

            //if (validationResult.IsValid)
            //{
            //    ModelState.Clear();

            //    validationResult.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));

            //    return View(loginDTO);
            //}
            //await _accountService.LoginAsync(loginDTO);
            //return Redirect("/Admin");

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogOut");
            }

            if (!ModelState.IsValid)
                return View();

            AppUser user = await _userManager.FindByEmailAsync(loginDTO.Email);

           
            

            if (user == null)
            {
                ModelState.AddModelError("", "UserNameOrEmail or password is not valid");
                return View();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Try again shortly");
                return View();
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserNameOrEmail or password is not correct");
                return View();
            }

            await _signInManager.SignInAsync(user, true);

            var role = await _userManager.GetRolesAsync(user);

            if (role.Contains("Admin"))
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }


    }

}
