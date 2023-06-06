using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Common.ViewModels.Booking
{
    public class BookingViewModel
    {
        //Время начала бронирования парк. места
        public DateTime? StartBookedTime { get; set; }

        //Время конца бронирования парк. места
        public DateTime? EndBookedTime { get; set; }

        //Внешний ключ парк. места
        public int IdLots { get; set; }

        //Внешний ключ пользователя
        public int IdUsers { get; set; }
    }
}
