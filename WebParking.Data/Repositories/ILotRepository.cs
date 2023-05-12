using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// Создание парк. мест
        /// </summary>
        /// <param name="lot"></param>
        /// <returns></returns>
        Task<LotEntityModel> AddLot(LotEntityModel lot);
    }
}
