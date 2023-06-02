using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common;
using WebParking.Common.ViewModels.Auth;
using WebParking.Data.Data;
using WebParking.Data.Entities;

namespace WebParking.Data.Repositories.Implementations
{
    public class UserRepository : BaseRepository<UserEntityModel>, IUserRepository

    {
        public UserRepository(ParkingContext _userContext) : base(_userContext)
        {
        }

        public async Task<UserEntityModel> Authenticate(LoginViewModel user)
        {
            return await GetQuery().FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);
        }

        public async Task<UserEntityModel> ForgotPassword(ForgotPasswordViewModel model)
        {
            return await GetQuery().FirstOrDefaultAsync(e => e.Email == model.Email);
        }

        public async Task<UserEntityModel> GetById(int id)
        {
            return await GetQuery().Include(r=>r.Role).FirstOrDefaultAsync(e => e.UserId == id);
        }

        public async Task<UserEntityModel> Register(RegisterViewModel user, IdentityRole role)
        {
            UserEntityModel userEntity = new UserEntityModel() { Password = user.Password, Email = user.Email, Role = role };
            return await InsertAsync(userEntity);
        }

        public async Task<UserEntityModel> ResetPassword(ResetPasswordViewModel model)
        {
            return await GetQuery().FirstOrDefaultAsync(e => e.Email == model.Email);
        }

        public async Task<bool> UserAlreadyExists(RegisterViewModel user)
        {
            return await GetQuery().AnyAsync(x => x.Email == user.Email);
        }
    }
}
