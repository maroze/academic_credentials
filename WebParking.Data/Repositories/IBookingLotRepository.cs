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
        public IEnumerable<UserLotEntityModel> GetUserBooks(int userId);

        public IEnumerable<UserLotEntityModel> GetBooks();

        /// <summary>
        /// Изменение бронирования
        /// </summary>
        /// <param name="lot"></param>
        /// <returns></returns>
        Task<UserLotEntityModel> UpdateBook(UserLotEntityModel lot);

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
        /// Получение брони по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserLotEntityModel> GetBook(int id);
    }
}
