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
using System.Web.Helpers;
using System.Web.WebPages;
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

            return _mapper.Map<UserModel>(loguser);
        }

        public async Task<UserModel> ChangePassword(ChangePasswordViewModel model)
        {
            if (model == null)
                throw new Exception("Старый пароль не указан");

            model.OldPassword = _passwordEncryption.HashPassword(model.OldPassword);
            model.NewPassword = _passwordEncryption.HashPassword(model.NewPassword);
            model.ConfirmPassword = _passwordEncryption.HashPassword(model.ConfirmPassword);

            return _mapper.Map<UserModel>(await _userRepository.ChangePassword(model));
        }
        //Почему не работает
        public async Task<UserModel> ChangeProfile(ProfileUserViewModel model, string email)
        {
            if (model == null)
                throw new Exception("Данные личного кабинета не указаны");

            var user = await _userRepository.GetByEmail(email);

            if (user == null)
                throw new Exception("Пользователя с таким id не существует");
            byte[] imageData = null;

            if (model.Avatar != null)
            {
                using (var binaryReader = new BinaryReader(model.Avatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)model.Avatar.Length);
                }
            }

            if (model.Email == null)
                throw new Exception("Почта не указана");
            if (user.Email != model.Email)
                if (await _userRepository.UserAlreadyExists(model.Email))
                    throw new Exception("Пользователь с такой почтой уже существует");

            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.PhoneNumber = model.PhoneNumber;
            user.LastName = model.LastName;
            user.PlateNumder = model.PlateNumder;
            user.Avatar = imageData;

            return _mapper.Map<UserModel>(await _userRepository.ChangeProfile(user));
        }

        public async Task<UserModel> DeleteUser(string email)
        {
            return _mapper.Map<UserModel>(await _userRepository.DeleteUser(email));
        }

        public async Task<UserModel> ForgotPassword(ForgotPasswordViewModel email)
        {
            if (email == null)
                throw new Exception("Почта пользователя не указана");

            var result = await _userRepository.ForgotPassword(email);

            if (result == null)
                throw new Exception("Пользователь с этой почтой не зарегистрирован");

            return _mapper.Map<UserModel>(result); ;
        }

        public async Task<ResponseProfileUserViewModel> GetUserByEmail(string email)
        {
            var result = await _userRepository.GetByEmail(email);

            if (result == null)
                throw new Exception("Пользователя не существует");

            return _mapper.Map<ResponseProfileUserViewModel>(result);
        }

        public async Task Register(RegisterViewModel user)
        {
            if (user == null)
                throw new Exception("Пользователь не указан");

            user.Password = _passwordEncryption.HashPassword(user.Password);
            user.ConfirmPassword = _passwordEncryption.HashPassword(user.ConfirmPassword);
            var role = await _roleManager.FindByNameAsync("user");

            await _userRepository.Register(user, role);
        }

        public async Task<UserModel> ResetPassword(ResetPasswordViewModel pass)
        {
            if (pass == null)
                throw new Exception("Пользователь не указан");

            pass.NewPassword = _passwordEncryption.HashPassword(pass.NewPassword);
            pass.NewConfirmPassword = _passwordEncryption.HashPassword(pass.NewConfirmPassword);
            var user = await _userRepository.ResetPassword(pass);

            return _mapper.Map<UserModel>(user);
        }

        public async Task<bool> UserAlreadyExists(string email)
        {
            return await _userRepository.UserAlreadyExists(email);
        }
    }
}