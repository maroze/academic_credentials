using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels.Parking;
using WebParking.Data.Entities;

namespace WebParking.Service.Models
{
    public class ParkingModel
    {
        /// <summary>
        /// id парковки
        /// </summary>
        public int ParkId { get; set; }

        /// <summary>
        /// Название парковки
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Адрес парковки
        /// </summary>
        public string? Adress { get; set; }

        /// <summary>
        /// Сетка парк. мест строки
        /// </summary>
        public int? Row { get; set; }

        /// <summary>
        /// Сетка парк. мест столбцы
        /// </summary>
        public int? Column { get; set; }

        /// <summary>
        /// Картинка парковки
        /// </summary>
        public byte[] Image { get; set; }
    }
}
