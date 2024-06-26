using PetShopPatte_Business.DTOs.AccountDTOs;
using PetShopPatte_Core.Entities.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Abstracts
{
    public interface IAccountService
    {
        Task CreateRoleAsync();
        Task<AppUser> GetUserByEmailAddress(string emailAddress);
        Task RegisterAsync(RegisterDTO registerDTO);
        Task LoginAsync(LoginDTO loginDTO);
        Task LogoutAsync();
    }
}
