﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Common.ViewModels.LotParking
{
    public class LotViewModel
    {
        public int LotId { get; set; }
        public int IdParks { get; set; }
        //Название парк. места
        public string? Name { get; set; }
       
        //Состояние парк. места доступно/недоступно для бронирования
        public bool IsBlocked { get; set; }
        
        //Состояние парк. места забронировано/свободно
        public bool IsBooked { get; set; }
    }
}
