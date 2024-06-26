using Microsoft.AspNetCore.Identity;
using PetShopPatte_Business.DTOs.AccountDTOs;
using PetShopPatte_Business.Services.Abstracts;
using PetShopPatte_Core.Entities.UserModel;
using PetShopPatte_Core.Enums;
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

        public async Task CreateRoleAsync()
        {
            foreach (var item in Enum.GetValues(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(item.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole(item.ToString()));
                }
            }
        }

        public async Task<AppUser> GetUserByEmailAddress(string emailAddress)
        {
            return await _userManager.FindByEmailAsync(emailAddress);
        }

        public async Task LoginAsync(LoginDTO loginDTO)
        {
            var existUser = await _userManager.FindByEmailAsync(loginDTO.Email);
            await _signInManager.SignInAsync(existUser, true);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task RegisterAsync(RegisterDTO registerDTO)
        {
            var user = new AppUser()
            {
                Email = registerDTO.Email,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
            };

            await _userManager.CreateAsync(user, registerDTO.Password);
            await _userManager.AddToRoleAsync(user, Roles.Admin.ToString());
        }
    }
}
