using Microsoft.AspNetCore.Mvc;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Business.Services.Concretes;

namespace PetShop_Patte.Controllers
{
    public class SendMessageController : Controller
    {
        private readonly ISendMessageService _sendService;

        public SendMessageController(ISendMessageService sendService)
        {
            _sendService = sendService;
        }

        public async Task<IActionResult> ConfirmEmailAddress(string emailAddress, string token)
        {
            if (!Request.Cookies.ContainsKey("ConfirmationLinkSent"))
            {
                return RedirectToAction(nameof(ConfirmationCookieExpired));
            }

            await _sendService.ConfirmEmailAddress(emailAddress, token);

            Response.Cookies.Delete("ConfirmationLinkSent");

            return RedirectToAction("Login", "Account");
        }

        public IActionResult ConfirmationCookieExpired()
        {
            return View();
        }
    }
}
