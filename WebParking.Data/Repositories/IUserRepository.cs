﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels.Auth;
using WebParking.Data.Entities;

namespace WebParking.Data.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="user"></param>
        Task<UserEntityModel> Register(RegisterViewModel user, IdentityRole role);

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<UserEntityModel> DeleteUser(string email);

        /// <summary>
        /// Изменение пароля пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UserEntityModel> ChangePassword(ChangePasswordViewModel model );

        /// <summary>
        /// Изменение личного кабинета
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UserEntityModel> ChangeProfile(UserEntityModel model);

        /// <summary>
        /// Проверка зарегистрирован пользователь 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<bool> UserAlreadyExists(string email);

        /// <summary>
        /// Аутентификация пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<UserEntityModel> Authenticate(LoginViewModel user);
        
        /// <summary>
        /// Забыли пароль
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UserEntityModel> ForgotPassword(ForgotPasswordViewModel model);

        /// <summary>
        /// Восстановление пароля
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UserEntityModel> ResetPassword(ResetPasswordViewModel model);

        /// <summary>
        /// Получение пользователя по email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<UserEntityModel> GetByEmail(string email);

        /// <summary>
        /// Получение пользователя по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserEntityModel> GetById(int id);
    }
}
