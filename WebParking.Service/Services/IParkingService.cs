﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels.Parking;
using WebParking.Data.Entities;
using WebParking.Service.Models;

namespace WebParking.Service.Services
{
    public interface IParkingService
    {
        /// <summary>
        /// Информация о парковке с заданным id из БД
         /// </summary>
        /// <param name="parkId"></param>
        /// <returns></returns>
        Task<ParkingModel> GetParking(int parkId);

        /// <summary>
        /// Создание парковки в БД
        /// </summary>
        /// <param name="park"></param>
        /// <returns></returns>
        Task<ParkingModel> AddParking(ParkingViewModel park);
       
        /// <summary>
        /// Информация о всех парковках
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ParkingModel> GetParkins();

        /// <summary>
        /// Обновление информации парковки
        /// </summary>
        /// <param name="parking"></param>
        /// <returns></returns>
        Task<ParkingModel> UpdateParking(ParkingViewModel parking);

        /// <summary>
        /// Удаление парковки
        /// </summary>
        /// <param name="parkingId"></param>
        /// <returns></returns>
        Task<ParkingModel> DeleteParking(int parkingId);

    }
}
