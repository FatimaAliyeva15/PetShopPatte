using Microsoft.AspNetCore.Identity;
using PetShopPatte_Business.DTOs.AccountDTOs;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Core.Entities.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopPatte_Business.Services.Concretes
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public Task CreateRoleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetUserByEmailAddress(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public Task LoginAsync(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public Task RegisterAsync(RegisterDTO registerDTO)
        {
            throw new NotImplementedException();
        }
    }
}
