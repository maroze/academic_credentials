using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Common.ViewModels
{
    /// <summary>
    /// Модель представления создания парковки
    /// </summary>
    public class ParkingViewModel
    {
        //Изображение парковки
        [Required]
        public IFormFile Image { get; set; }

        [Required]
        //Название парковки
        public string? Name { get; set; }

        [Required]
        //Адрес парковки
        public string Adress { get; set; }
    }
}
