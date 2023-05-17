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
        [Column("lot_id")]
        public int LotId { get; set; }

        //Название парк. места
        [Column("name")]
        public string Name { get; set; }

        //Состояние парк. места доступно/недоступно для бронирования
        [Column("is_bloked")]
        public bool IsBlocked { get; set; }

        //Состояние парк. места забронировано/свободно
        [Column("is_booked")]
        public bool IsBooked { get; set; }

        //Внешний ключ парковки
        [Column("id_parkings")]
        public int IdParks { get; set; }
        public ParkingEntityModel Parks { get; set; }        
    }
}
