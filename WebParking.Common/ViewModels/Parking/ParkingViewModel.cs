using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Common.ViewModels.Parking
{
    public class ParkingViewModel
    {
        public string? Name { get; set; }

        public string? Adress { get; set; }

        public int? Row { get; set; }

        public int? Column { get; set; }

        public IFormFile? Image { get; set; }
    }
}
