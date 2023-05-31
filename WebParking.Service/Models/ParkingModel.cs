﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels.Parking;
using WebParking.Data.Entities;

namespace WebParking.Service.Models
{
    public class ParkingModel
    {
        public IFormFile Image { get; set; }

        //Название парковки
        public string? Name { get; set; }

        //Адрес парковки
        public string Adress { get; set; }
    }
}
