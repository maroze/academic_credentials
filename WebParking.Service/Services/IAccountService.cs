using Library.Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Service.Models;

namespace WebParking.Service.Services
{
    public interface IAccountService
    {
        /// <summary>
        /// Создание нового пользователя (регистрация)
        /// </summary>
        /// <param name="model"> Модель нового пользователя </param>
        /// <returns> Результат выполнения метода </returns>
        Task<UserModel> CreateUser(RegisterViewModel model);


        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="model"> Модель авторизации </param>
        /// <returns> Результат авторизации </returns>
        Task<UserModel> Authorization(LoginViewModel model);

        
    }
}

