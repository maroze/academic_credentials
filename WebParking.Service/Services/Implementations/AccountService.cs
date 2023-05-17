using Library.Common.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Crypto;
using System;
using System.Security.Cryptography;
using System.Security.Policy;
using WebParking.Common;
using WebParking.Common.ViewModels;
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


        public AccountService(IUserRepository userRepository, IPasswordEncryption passwordEncryption)
        {
            _userRepository = userRepository;
            _passwordEncryption = passwordEncryption;
        }

        public async Task<UserModel> Authenticate(LoginViewModel user)
        {
            if (user == null)
                throw new Exception("Пользователь не указан");

            user.Password = _passwordEncryption.HashPassword(user.Password);
            return await _userRepository.Authenticate(user);
        }

        public async Task<UserModel> ForgotPassword(ForgotPasswordViewModel email)
        {
            if (email == null)
                throw new Exception("Почта пользователя не указана");

            var result = _userRepository.ForgotPassword(email);
            
            if (result == null)
            {
                throw new Exception("Пользователь с этой почтой не зарегистрирован");
            }

            return await result;
        }

        public async void Register(RegisterViewModel user)
        {
            if (user == null)
                throw new Exception("Пользователь не указан");

            user.Password = _passwordEncryption.HashPassword(user.Password);
            user.ConfirmPassword= _passwordEncryption.HashPassword(user.ConfirmPassword);
            _userRepository.Register(user);
        }

        //Еще думаю как лучше сделать, в гугле только решения с помощью Identity 
        //public async Task<UserModel> ResetPassword(ResetPasswordViewModel pass)
        //{
        //    var user = await _userRepository.ResetPassword(pass);
            
        //    if (user != null )
        //    {
        //        pass.NewPasswod = _passwordEncryption.HashPassword(pass.NewPasswod);
        //        pass.NewConfirmPassword = _passwordEncryption.HashPassword(pass.NewConfirmPassword);
        //        return  user;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public async Task<bool> UserAlreadyExists(RegisterViewModel user)
        {
            return await _userRepository.UserAlreadyExists(user);
        }
    }
}