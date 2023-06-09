﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Common.ViewModels.Parking
{
    public class ParkingUpdateViewModel
    {
        public int ParkId { get; set; }
        //Изображение парковки

        public IFormFile? Image { get; set; }

        //Название парковки
        public string? Name { get; set; }

        //Адрес парковки
        public string? Adress { get; set; }
    }
}