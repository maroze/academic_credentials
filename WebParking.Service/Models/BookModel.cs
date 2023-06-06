using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Service.Models
{
    public class BookModel
    { 
        //Время начала бронирования парк. места
        public DateTime? StartBookedTime { get; set; }

        //Время конца бронирования парк. места
        public DateTime? EndBookedTime { get; set; }

        //Внешний ключ парк. места
        public int IdLots { get; set; }

        //Внешний ключ пользователя
        public int IdUsers { get; set; }

        public bool IsExpired { get; set; }
    }
}
