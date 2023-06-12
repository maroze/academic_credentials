using Microsoft.AspNetCore.Http;
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

        public string? Name { get; set; }

        public string? Adress { get; set; }

        public int? Row { get; set; }

        public int? Column { get; set; }

        public IFormFile? Image { get; set; }
    }
}
