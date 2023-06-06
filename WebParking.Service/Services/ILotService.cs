using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels;
using WebParking.Common.ViewModels.LotParking;
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
        public IEnumerable<LotModel> GetLots(int idpark);


        /// <summary>
        /// Обновление информации места парковки
        /// </summary>
        /// <param name="lot"></param>
        /// <returns></returns>
        Task<LotModel> UpdateLot(LotUpdateViewModel lot);

        /// <summary>
        /// Удаление места парковки
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        Task<LotModel> DeleteLot(int lotId);

        /// <summary>
        /// Создание парк. мест
        /// </summary>
        /// <param name="lot"></param>
        /// <returns></returns>
        Task<LotModel> AddLot(LotViewModel lot);
    }
}
