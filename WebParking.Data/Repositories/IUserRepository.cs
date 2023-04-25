using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Data.Entities;

namespace WebParking.Data.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Информация о всех пользователях
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserEntityModel> GetUsers();

        /// <summary>
        /// Информация о пользователе по id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserEntityModel> GetUser(int userId);

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<UserEntityModel> CreateUser(UserEntityModel user);

        /// <summary>
        /// Редактирование пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<UserEntityModel> UpdateUser(UserEntityModel user);

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="userId"></param>
        Task<UserEntityModel> DeleteUser(int userId);
    }
}
