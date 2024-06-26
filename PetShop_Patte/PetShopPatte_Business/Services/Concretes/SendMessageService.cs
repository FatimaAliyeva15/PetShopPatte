using Microsoft.AspNetCore.Identity;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Core.Entities.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Concretes
{
    public class SendMessageService : ISendMessageService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAccountService _accountService;

        public SendMessageService(UserManager<AppUser> userManager, IAccountService accountService)
        {
            _userManager = userManager;
            _accountService = accountService;
        }

        public async Task<IdentityResult> ConfirmEmailAddress(string userEmailAddress, string token)
        {
            var existUser = await _accountService.GetUserByEmailAddress(userEmailAddress);

            if (existUser == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = $"User with email '{userEmailAddress}' not found." });
            }

            var result = await _userManager.ConfirmEmailAsync(existUser, token);
            return result;
        }

        public async Task<string> GenerateTokenAsync(string userName)
        {
            var user = await _accountService.GetUserByEmailAddress(userName);

            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public void SendMessage(string user, string url)
        {
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential("fatimaaliyeva.04@gmail.com", "ptsh pptt dplm bcsd"); 

                MailMessage mailMessage = new MailMessage()
                {
                    From = new MailAddress("fatimaaliyeva.04@gmail.com"),
                    Subject = "Welcome to PetShop Patte",
                    Body = $"<p>Hello,</p><p>Welcome to PetShop Patte! Please visit the following URL to complete your registration:</p><p><a href='{url}'>{url}</a></p><p>Best regards,<br/>PetShop Patte Team</p>",
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(user);
                client.Send(mailMessage);
            }
        }

        public async Task SendMessageAsync(string userEmailAddress, string url)
        {
            var newUser = await _accountService.GetUserByEmailAddress(userEmailAddress);

            SendMessage(
                user: newUser.Email,
                url: url
                );
        }
    }
}
