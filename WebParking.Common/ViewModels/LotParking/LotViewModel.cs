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
        public int IdParks { get; set; }

        public string? Name { get; set; }
       
        public bool IsBlocked { get; set; }
        
        public bool IsBooked { get; set; }
    }
}
