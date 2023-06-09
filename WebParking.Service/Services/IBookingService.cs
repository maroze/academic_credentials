using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels.Booking;
using WebParking.Data.Entities;
using WebParking.Service.Models;

namespace WebParking.Service.Services
{
    public interface IBookingService
    {
        /// <summary>
        /// Информация о всех забронированных местах пользователя
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BookModel> GetUserBooks(int userId);
        public IEnumerable<BookModel> GetBooks();
        /// <summary>
        /// Изменение бронирования
        /// </summary>
        /// <param name="lot"></param>
        /// <returns></returns>
        Task<BookModel> UpdateBook(ChangeBookingViewModel lot);

        /// <summary>
        /// Удаление брони
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        Task<BookModel> DeleteBook(int lotId);

        /// <summary>
        /// Бронирование парк. мест
        /// </summary>
        /// <param name="lot"></param>
        /// <returns></returns>
        Task<BookModel> AddBook(BookingViewModel lot);
    }
}
