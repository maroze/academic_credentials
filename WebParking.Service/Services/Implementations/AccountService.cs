using Library.Common.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> Authenticate(LoginViewModel user)
        {
            return await _userRepository.Authenticate(user);
        }

        public async void Register(RegisterViewModel user)
        {
             _userRepository.Register(user);
        }

        public async Task<bool> UserAlreadyExists(RegisterViewModel user)
        {
            return await _userRepository.UserAlreadyExists(user);
        }
    }
}