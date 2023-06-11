using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Data.Entities;

namespace WebParking.Data.Repositories
{
    public interface IBookingLotRepository
    {
        /// <summary>
        /// Информация о всех забронированных местах пользователя
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserLotEntityModel> GetUserBooks(int id);

        /// <summary>
        /// Выборка всех броней, который должны начаться через минуту от текущего времени 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserLotEntityModel> GetStartBooks();

        /// <summary>
        /// Выборка всех броней, который должны закончится  
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserLotEntityModel> GetEndBooks();

        /// <summary>
        /// Удаление брони
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        Task<UserLotEntityModel> DeleteBook(int lotId);

        /// <summary>
        /// Бронирование парк. мест
        /// </summary>
        /// <param name="lot"></param>
        /// <returns></returns>
        Task<UserLotEntityModel> AddBook(UserLotEntityModel lot);

        /// <summary>
        /// Обновление брони
        /// </summary>
        /// <param name="lot"></param>
        /// <returns></returns>
        Task<UserLotEntityModel> UpdateBook(UserLotEntityModel lot);

        /// <summary>
        /// Получение брони по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserLotEntityModel> GetBook(int id);
    }
}
