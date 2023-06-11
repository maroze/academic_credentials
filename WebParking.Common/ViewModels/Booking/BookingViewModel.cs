﻿using System;
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
        [DataType(DataType.DateTime)]
        public DateTime? StartBookedTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? EndBookedTime { get; set; }

        public int IdLots { get; set; }

        public int IdUsers { get; set; }
    }
}
