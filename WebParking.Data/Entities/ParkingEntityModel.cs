using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Data.Entities
{
    [Table("Parks")]
    public class ParkingEntityModel
    {
        //Id парковки
        [Key]
        public int ParkId { get; set; }

        //Фото парковочных мест
        public byte[] Image { get; set; }

        //Название парковки
        public string? Name { get; set; }

        //Адрес парковки
        public string Adress { get; set; }
    }
}
