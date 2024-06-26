using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Abstracts
{
    public interface ISendMessageService
    {
        void SendMessage(string user, string url);
        Task SendMessageAsync(string userEmailAddress, string url);
        Task<string> GenerateTokenAsync(string userName);
        Task<IdentityResult> ConfirmEmailAddress(string userEmailAddress, string token);
    }
}
