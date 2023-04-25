using Library.Common.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebParking.Data.Data;
using WebParking.Data.Entities;

namespace WebParking.Data.Repositories.Implementations
{
    public class UserRepository : BaseRepository<UserEntityModel>, IUserRepository
    {
        private readonly ParkingContext context;
        public UserRepository(ParkingContext _userContext) : base(_userContext)
        {
            context = _userContext;
        }

        public async Task<UserEntityModel> Authenticate(LoginViewModel user)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);
        }
        public void Register(RegisterViewModel user)
        {
            byte[] passwordHash, passwordKey;

            using (var hmac = new HMACSHA512())
            {
                passwordKey = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(user.Password));
            }
            UserEntityModel userEntity = new UserEntityModel() { Password = passwordHash, PasswordKey = passwordKey };
            context.Users.Add(userEntity);
        }

        public async Task<bool> UserAlreadyExists(RegisterViewModel user)
        {
            return await context.Users.AnyAsync(x => x.Email == user.Email);
        }

        public async Task<UserEntityModel> CreateUser(UserEntityModel user)
        {
            Insert(user);
            return await Task.FromResult(user);
        }

        public Task<UserEntityModel> DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntityModel> GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntityModel> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<UserEntityModel> UpdateUser(UserEntityModel user)
        {
            throw new NotImplementedException();
        }
    }
}
