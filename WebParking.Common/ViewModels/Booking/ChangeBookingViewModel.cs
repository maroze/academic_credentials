using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Common.ViewModels.Booking
{
    public class ChangeBookingViewModel
    {
        public int UserLotId { get; set; }

        //Время начала бронирования парк. места
        public DateTime? StartBookedTime { get; set; }

        //Время конца бронирования парк. места
        public DateTime? EndBookedTime { get; set; }
    }
}
