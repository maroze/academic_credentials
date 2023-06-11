using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels.Auth;
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
        Task Register(RegisterViewModel user);

        /// <summary>
        /// Проверка существует пользователь 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> UserAlreadyExists(string email);

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
        Task<UserModel> ResetPassword(ResetPasswordViewModel pass);

        /// <summary>
        /// Получение пользователя по email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<ResponseProfileUserViewModel> GetUserByEmail(string email);

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<UserModel> DeleteUser(string email);

        /// <summary>
        /// Изменение пароля пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UserModel> ChangePassword(ChangePasswordViewModel model);

        /// <summary>
        /// Изменение личного кабинета
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UserModel> ChangeProfile(ProfileUserViewModel model, string email);
    }
}

