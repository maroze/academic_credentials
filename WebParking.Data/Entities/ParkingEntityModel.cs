using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Data.Entities
{
    [Table("Parkings")]
    public class ParkingEntityModel
    {
        /// <summary>
        /// Id парковки
        /// </summary>
        [Key]
        [Column("parking_id")]
        public int ParkId { get; set; }

        /// <summary>
        /// Фото парковочных мест
        /// </summary>
        [Column("image")]
        public byte[] Image { get; set; }

        /// <summary>
        /// Название парковки
        /// </summary>
        [Column("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Адрес парковки
        /// </summary>
        [Column("adress")]
        public string? Adress { get; set; }
    }
}
