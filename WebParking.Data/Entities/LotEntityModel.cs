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
        /// <summary>
        /// Id парковочного места
        /// </summary>
        [Key]
      
        [Column("lot_id")]
        public int LotId { get; set; }
/// <summary>
        /// Внешний ключ парковки
        /// </summary>
        [Column("id_parkings")]
        public int IdParks { get; set; }
        public ParkingEntityModel Parks { get; set; }  
        /// <summary>
        /// Название парк. места
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Состояние парк. места доступно/недоступно для бронирования
        /// </summary>
        [Column("is_bloked")]
        public bool IsBlocked { get; set; }

        /// <summary>
        /// Состояние парк. места забронировано/свободно
        /// </summary>
        [Column("is_booked")]
        public bool IsBooked { get; set; }

        public List<UserLotEntityModel> UserLots { get; set; }
    }
}
