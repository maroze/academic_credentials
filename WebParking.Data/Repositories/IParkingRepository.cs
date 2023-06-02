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
        /// Информация о всех парковках
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ParkingEntityModel> GetParkins();

        /// <summary>
        /// Обновление информации парковки
        /// </summary>
        /// <param name="parking"></param>
        /// <returns></returns>
        Task<ParkingEntityModel> UpdateParking(ParkingEntityModel parking);

        /// <summary>
        /// Удаление парковки
        /// </summary>
        /// <param name="parkingId"></param>
        /// <returns></returns>
        Task<ParkingEntityModel> DeleteParking(int parkingId);

        /// <summary>
        /// Создание парковки
        /// </summary>
        /// <param name="park"></param>
        /// <returns></returns>
        Task<ParkingEntityModel> AddParking(ParkingEntityModel park);

    }
}
