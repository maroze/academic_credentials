using Library.Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using WebParking.Data.Entities;
using WebParking.Data.Repositories;
using WebParking.Service.Models;

namespace WebParking.Service.Services.Implementations
{
    public class AccountService : IAccountService
    {

        private readonly IUserRepository _userRepository;
        private readonly UserEntityModel _user;
        public AccountService(IUserRepository userRepository, UserEntityModel user)
        {
            _userRepository = userRepository;
            _user = user;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login (LoginViewModel model)
        {
            var user = await _userRepository.Authenticate
        }

        public Task<UserModel> Authorization(LoginViewModel model)
        {
            throw new NotImplementedException();
        }
        public byte[] CreateHash(string password)
        {
            byte[] passwordHash = new HMACSHA512().ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return passwordHash;
        }
        public async Task<UserModel> CreateUser(RegisterViewModel model)
        {
            var pass = await Fis
            var result = await _userRepository.CreateUser(model);
            return result;
        }

    }
}