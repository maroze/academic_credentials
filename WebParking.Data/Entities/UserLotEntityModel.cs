using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Data.Entities
{
    [Table("UserLots")]
    public class UserLotEntityModel
    {
        /// <summary>
        /// Id парковочного места пользователя
        /// </summary>
        [Key]
        [Column("user_lot_id")]
        public int UserLotId { get; set; }

        /// <summary>
        /// Время начала бронирования парк. места
        /// </summary>
        [Column("booked_start_at")]
        public DateTime? StartBookedTime { get; set; }

        /// <summary>
        /// Время конца бронирования парк. места
        /// </summary>
        [Column("booked_end_at")]
        public DateTime? EndBookedTime { get; set; }

        /// <summary>
        /// Внешний ключ парк. места
        /// </summary>
        [Column("id_lots")]
        public int IdLots { get; set; }
        public LotEntityModel Lots { get; set; }

        /// <summary>
        /// Внешний ключ пользователя
        /// </summary>
        [Column("is_users")]
        public int IdUsers { get; set; }
        public UserEntityModel Users { get; set; }

        /// <summary>
        /// Состояние брони истекла/неистекла
        /// </summary>
        public bool IsExpired { get; set; }
    }
}
