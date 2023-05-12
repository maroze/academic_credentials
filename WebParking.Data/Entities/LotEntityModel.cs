using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Data.Entities
{
    [Table("Lots")]
    public class LotEntityModel
    {
        //Id парковочного места
        [Key]
        public int LotId { get; set; }

        //Название парк. места
        public string Name { get; set; }

        //Состояние парк. места доступно/недоступно для бронирования
        public bool IsBlocked { get; set; }

        //Состояние парк. места забронировано/свободно
        public bool IsBooked { get; set; }

        //Внешний ключ парковки
        public int IdParks { get; set; }
        public ParkingEntityModel Parks { get; set; }

        //Внешний ключ пользователя
        public int IdUsers { get; set; }
        public UserEntityModel Users { get; set; }
        
    }
}
