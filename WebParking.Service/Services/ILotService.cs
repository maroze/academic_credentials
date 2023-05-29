using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels;
using WebParking.Data.Entities;
using WebParking.Service.Models;

namespace WebParking.Service.Services
{
    public interface ILotService
    {
        /// <summary>
        /// Информация о парк. месте с заданным id
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        Task<LotModel> GetLot(int lotId);

        /// <summary>
        /// Информация о всех парк. местах
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LotModel> GetLots();

        /// <summary>
        /// Бронирование парк. места
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        Task<LotModel> BookLot(int lotId);

        /// <summary>
        /// Создание парк. мест
        /// </summary>
        /// <param name="lot"></param>
        /// <returns></returns>
        Task<LotModel> AddLot(LotModel lot);
    }
}
