using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Crypto;
using System;
using System.Data;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Policy;
using WebParking.Common;
using WebParking.Common.ViewModels.Auth;
using WebParking.Data.Entities;
using WebParking.Data.Repositories;
using WebParking.Service.Models;
using WebParking.Services.EmailServices;

namespace WebParking.Service.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordEncryption _passwordEncryption;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AccountService(IUserRepository userRepository, IPasswordEncryption passwordEncryption, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordEncryption = passwordEncryption;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<UserModel> Authenticate(LoginViewModel user)
        {
            if (user == null)
                throw new Exception("Пользователь не указан");

            user.Password = _passwordEncryption.HashPassword(user.Password);
            var loguser = await _userRepository.Authenticate(user);
            return _mapper.Map<UserModel>( loguser);
        }

        public async Task<UserModel> ForgotPassword(ForgotPasswordViewModel email)
        {
            if (email == null)
                throw new Exception("Почта пользователя не указана");

            var result = await _userRepository.ForgotPassword(email);

            if (result == null)
            {
                throw new Exception("Пользователь с этой почтой не зарегистрирован");
            }

            return _mapper.Map<UserModel>(result); ;
        }


        public async Task<UserEntityModel> GetUserById(int id)
        {
            if (id == null)
                throw new Exception("Id пользователя не указан");
            var result = await _userRepository.GetById(id);

            if (result == null)
            {
                throw new Exception("Пользователя не существует");
            }
            return result;

        }

        public async Task Register(RegisterViewModel user)
        {
            if (user == null)
                throw new Exception("Пользователь не указан");

            user.Password = _passwordEncryption.HashPassword(user.Password);
            user.ConfirmPassword = _passwordEncryption.HashPassword(user.ConfirmPassword);

            await _userRepository.Register(user, await _roleManager.FindByNameAsync("user"));
           
        }

        public async Task<UserModel> ResetPassword(ResetPasswordViewModel pass)
        {
            if (pass == null)
                throw new Exception("Пользователь не указан");
            var user = await _userRepository.ResetPassword(pass);

            if (user != null)
            {
                pass.NewPasswod = _passwordEncryption.HashPassword(pass.NewPasswod);
                pass.NewConfirmPassword = _passwordEncryption.HashPassword(pass.NewConfirmPassword);
            }
            return _mapper.Map<UserModel>(user);
        }

        public async Task<bool> UserAlreadyExists(RegisterViewModel user)
        {
            return await _userRepository.UserAlreadyExists(user);
        }
    }
}