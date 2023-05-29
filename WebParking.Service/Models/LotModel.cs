using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels;
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
        public static implicit operator LotEntityModel(LotModel model)
        {

            if (model == null)
            {

                return null;

            }
            else return new LotEntityModel
            {
                LotId = model.LotId,
                Name = model.Name,
                IsBlocked = model.IsBlocked,
                IsBooked = model.IsBooked,
                IdParks =model.IdParks
            };
        }
        public static implicit operator LotModel(LotEntityModel model)
        {

            if (model == null)
            {

                return null;

            }
            else return new LotModel
            {
                LotId = model.LotId,
                Name = model.Name,
                IsBlocked = model.IsBlocked,
                IsBooked = model.IsBooked,
                IdParks = model.IdParks
            };
        }
        public static implicit operator LotViewModel(LotModel model)
        {

            if (model == null)
            {

                return null;

            }
            else return new LotViewModel
            {
                LotId = model.LotId,
                Name = model.Name,
                IsBlocked = model.IsBlocked,
                IsBooked = model.IsBooked
            };
        }
        public static implicit operator LotModel(LotViewModel model)
        {

            if (model == null)
            {

                return null;

            }
            else return new LotModel
            {
                LotId = model.LotId,
                Name = model.Name,
                IsBlocked = model.IsBlocked,
                IsBooked = model.IsBooked
            };
        }
    }
}
