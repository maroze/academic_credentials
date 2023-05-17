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
        //Id парковки
        [Key]
        [Column("parking_id")]
        public int ParkId { get; set; }

        //Фото парковочных мест
        [Column("image")]
        public byte[] Image { get; set; }

        //Название парковки
        [Column("name")]
        public string? Name { get; set; }

        //Адрес парковки
        [Column("adress")]
        public string? Adress { get; set; }
    }
}
