using FluentValidation;
using Microsoft.AspNetCore.Identity;
using PetShopPatte_Business.Exceptions.AccountExceptions;
using PetShopPatte_Core.Entities.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.DTOs.AccountDTOs
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginDTOValidation: AbstractValidator<LoginDTO>
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;
        public LoginDTOValidation(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            RuleFor(x => x.Email)
               .NotEmpty()
               .WithMessage("Please enter username or email address!")
               .MustAsync(BeAValidUser)
               .WithMessage("Email address or password is not valid!");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Please enter your password!")
                .MustAsync(BeAValidPassword)
                .WithMessage("Email address or password is not valid!");

        }

        private async Task<bool> BeAValidUser(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user != null;
        }

        private async Task<bool> BeAValidPassword(LoginDTO loginDTO, string password, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                return false;
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, true);
            if (result.IsLockedOut)
            {
                throw new UserLoginException("Your account is lockout, please try again later!");
            }

            return result.Succeeded;
        }

    }
}
