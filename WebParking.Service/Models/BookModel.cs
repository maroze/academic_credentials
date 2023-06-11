using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Service.Models
{
    public class BookModel
    {
        /// <summary>
        /// Id брони
        /// </summary>
        public int UserLotId { get; set; }

        /// <summary>
        /// Время начала бронирования парк. места
        /// </summary>
        public DateTime? StartBookedTime { get; set; }

        /// <summary>
        /// Время конца бронирования парк. места
        /// </summary>
        public DateTime? EndBookedTime { get; set; }

        /// <summary>
        /// Внешний ключ парк. места
        /// </summary>
        public int IdLots { get; set; }

        /// <summary>
        /// Внешний ключ пользователя
        /// </summary>
        public int IdUsers { get; set; }

        /// <summary>
        /// Состояние брони истекшая/текущая
        /// </summary>
        public bool IsExpired { get; set; }
    }
}
