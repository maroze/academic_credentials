using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels.LotParking;
using WebParking.Data.Entities;

namespace WebParking.Service.Models
{
    public class LotModel
    {
        public int LotId{get;set;}
        //Название парк. места
        public string Name { get; set; }
        //Состояние парк. места доступно/недоступно для бронирования
        public bool IsBlocked { get; set; }
        //Состояние парк. места забронировано/свободно
        public bool IsBooked { get; set; }
        public int IdParks { get; set; }
    }
}
