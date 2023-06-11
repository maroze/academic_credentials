using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels.LotParking;
using WebParking.Data.Entities;

namespace WebParking.Service.Models
{
    public class LotModel
    {
        /// <summary>
        /// id места парковки
        /// </summary>
        public int LotId{get;set;}

        /// <summary>
        /// Внешний ключ парковки
        /// </summary>
        public int IdParks { get; set; }

        /// <summary>
        /// Название парк. места
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Состояние парк. места доступно/недоступно для бронирования
        /// </summary>
        public bool IsBlocked { get; set; }

        /// <summary>
        /// Состояние парк. места забронировано/свободно
        /// </summary>
        public bool IsBooked { get; set; }
        
    }
}
