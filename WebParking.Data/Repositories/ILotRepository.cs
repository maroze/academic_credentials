using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels;
using WebParking.Data.Entities;

namespace WebParking.Data.Repositories
{
    public interface ILotRepository
    {
        /// <summary>
        /// Информация о парк. месте с заданным id
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        Task<LotEntityModel> GetLot(int lotId);

        /// <summary>
        /// Информация о всех парк. местах
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LotEntityModel> GetLots();

        /// <summary>
        /// Бронирование парк. места
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        //Task<LotEntityModel> BookLot(int lotId);

        /// <summary>
        /// Обновление информации места парковки
        /// </summary>
        /// <param name="lot"></param>
        /// <returns></returns>
        Task<LotEntityModel> UpdateLot(LotEntityModel lot);

        /// <summary>
        /// Удаление места парковки
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        Task<LotEntityModel> DeleteLot(int lotId);

        /// <summary>
        /// Создание парк. мест
        /// </summary>
        /// <param name="lot"></param>
        /// <returns></returns>
        Task<LotEntityModel> AddLot(LotEntityModel lot);
    }
}
