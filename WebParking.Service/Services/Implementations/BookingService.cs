using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels.Booking;
using WebParking.Data.Entities;
using WebParking.Data.Repositories;
using WebParking.Data.Repositories.Implementations;
using WebParking.Service.Models;

namespace WebParking.Service.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingLotRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILotRepository _lotRepository;
        private readonly IUserRepository _userRepository;
        public BookingService(IBookingLotRepository bookRepository, IMapper mapper, ILotRepository lotRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _lotRepository = lotRepository;
            _userRepository = userRepository;
        }

        public async Task<BookModel> AddBook(BookingViewModel lot)
        {
            if (lot == null)
                throw new Exception("Парк место не указано");

            var res = await _lotRepository.GetLot(lot.IdLots);
            var user = await _userRepository.GetById(lot.IdUsers);

            if ((res == null) || (user == null))
                throw new Exception("Парк место или/и пользователь не найден");

            if (res.IsBooked || res.IsBlocked)
                throw new Exception("Парк место недоступно для бронирования");

            var book = _mapper.Map<UserLotEntityModel>(lot);

            return _mapper.Map<BookModel>(await _bookRepository.AddBook(book));
        }

        public async Task<BookModel> DeleteBook(int lotId)
        {
            var get = await _bookRepository.GetBook(lotId);

            if (get == null)
                throw new Exception("Такой брони нет");

            var lot = await _lotRepository.GetLot(get.IdLots);
            lot.IsBooked = false;
            await _lotRepository.UpdateLot(lot);

            return _mapper.Map<BookModel>(await _bookRepository.DeleteBook(lotId));
        }

        public IEnumerable<BookModel> GetBooks()
        {
            var book_list = _bookRepository.GetStartBooks();            
            return _mapper.Map<IEnumerable<BookModel>>(book_list);
        }

        public IEnumerable<BookModel> GetUserBooks(int id)
        {
            var book_list = _bookRepository.GetUserBooks(id);
            return _mapper.Map<IEnumerable<BookModel>>(book_list);
        }
    }
}
