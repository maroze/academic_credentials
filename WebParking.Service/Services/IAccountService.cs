using Library.Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}

