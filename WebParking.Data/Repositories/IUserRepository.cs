using Microsoft.AspNetCore.Identity;
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
        /// Получение пользователя по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserEntityModel> GetById(int id);


    }
}
