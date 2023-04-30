using Library.Common.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common;
using WebParking.Data.Data;
using WebParking.Data.Entities;

namespace WebParking.Data.Repositories.Implementations
{
    public class UserRepository : BaseRepository<UserEntityModel>, IUserRepository

    {
        private readonly IPasswordEncryption passwordEncryption;
        public UserRepository(ParkingContext _userContext, IPasswordEncryption passwordEncryption) : base(_userContext)
        {
            this.passwordEncryption = passwordEncryption;
        }

        public async Task<UserEntityModel> Authenticate(LoginViewModel user)
        {
            return await GetQuery().FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == passwordEncryption.HashPassword(user.Password));
        }
        public void Register(RegisterViewModel user)
        {
            UserEntityModel userEntity = new UserEntityModel() { Password = passwordEncryption.HashPassword(user.Password), Email = user.Email };
            Insert(userEntity);
        }

        public async Task<bool> UserAlreadyExists(RegisterViewModel user)
        {
            return await GetQuery().AnyAsync(x => x.Email == user.Email);
        }
    }
}
