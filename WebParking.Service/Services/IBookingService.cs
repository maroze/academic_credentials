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
        /// Информация о всех бронях пользователя
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BookModel> GetUserBooks(int id);

        /// <summary>
        /// Информация о всех бронях
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BookModel> GetBooks();

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
