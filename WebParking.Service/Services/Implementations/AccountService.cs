using Library.Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using WebParking.Data.Entities;
using WebParking.Data.Repositories;
using WebParking.Services;

namespace WebParking.Service.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<UserEntityModel> userManager;
        private readonly SignInManager<UserEntityModel> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountService(SignInManager<UserEntityModel> signInManager, UserManager<UserEntityModel> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpViewModel model)
        {
            UserEntityModel user = new UserEntityModel()
            {
                LastName = model.LastName,
                FirstName = model.FirstName
            };

            return await userManager.CreateAsync(user, model.Password);
        }

        public Task<SignInResult> SignInAsync(SignInViewModel model)
        {
            if (model != null)
            {
                var result = signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                return JwtService.GenerateSecurityToken(model);
            }

        }
    }
}