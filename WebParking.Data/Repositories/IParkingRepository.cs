using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels;
using WebParking.Data.Entities;

namespace WebParking.Data.Repositories
{
    public interface IParkingRepository
    {
        /// <summary>
        /// Информация о парковке с заданным id
        /// </summary>
        /// <param name="parkId"></param>
        /// <returns></returns>
        Task<ParkingEntityModel> GetParking(int parkId);

        /// <summary>
        /// Создание парковки
        /// </summary>
        /// <param name="park"></param>
        /// <returns></returns>
        Task<ParkingEntityModel> AddParking(ParkingEntityModel park);

    }
}
