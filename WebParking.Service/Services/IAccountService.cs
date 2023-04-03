using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Service.Services
{
    public interface IAuthService
    {
        /// <summary>
        /// Регистрация пользователя в БД
        /// </summary>
        /// <returns></returns>
        Task<AuthModel> Register(UserModel model);

        /// <summary>
        /// Авторизация пользователя в БД
        /// </summary>
        /// <returns></returns>
        Task<AuthModel> Login(UserModel model);
    }
}

