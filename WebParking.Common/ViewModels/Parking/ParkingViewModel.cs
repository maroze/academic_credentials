using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Common.ViewModels.Parking
{
    /// <summary>
    /// Модель представления создания парковки
    /// </summary>
    public class ParkingViewModel
    {
        //Изображение парковки
        [Required]
        public IFormFile Image { get; set; }

        //Название парковки
        public string? Name { get; set; }

        //Адрес парковки
        public string? Adress { get; set; }
    }
}
