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
        //Id парковочного места пользователя
        [Key]
        [Column("user_lot_id")]
        public int UserLotId { get; set; }

        //Время бронирования парк. места
        [Column("booked_at")]
        public string BookedTime { get; set; }

        //Внешний ключ парк. места
        [Column("id_lots")]
        public int IdLots { get; set; }
        public LotEntityModel Lots { get; set; }

        //Внешний ключ пользователя
        [Column("is_users")]
        public int IdUsers { get; set; }
        public UserEntityModel Users { get; set; }
    }
}
