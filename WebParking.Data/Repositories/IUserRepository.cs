using Library.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels;
using WebParking.Data.Entities;

namespace WebParking.Data.Repositories
{
    public interface IUserRepository
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
        Task<UserEntityModel> Authenticate(LoginViewModel user);
        
        /// <summary>
        /// Восстановление пароля
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UserEntityModel> ForgotPassword(ForgotPasswordViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UserEntityModel> ResetPassword(ResetPasswordViewModel model);


    }
}
