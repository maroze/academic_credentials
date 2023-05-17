using Library.Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels;
using WebParking.Data.Entities;
using WebParking.Service.Models;

namespace WebParking.Service.Services
{
    public interface IAccountService
    {
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="user"></param>
        void Register(RegisterViewModel user);

        /// <summary>
        /// Проверка существует пользователь 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> UserAlreadyExists(RegisterViewModel user);

        /// <summary>
        /// Аутентификация пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<UserModel> Authenticate(LoginViewModel user);

        /// <summary>
        /// Пользователь забыл пароль
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<UserModel> ForgotPassword(ForgotPasswordViewModel email);

        /// <summary>
        /// Восстановление пароля
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        //Task<UserModel> ResetPassword(ResetPasswordViewModel pass);
    }
}

