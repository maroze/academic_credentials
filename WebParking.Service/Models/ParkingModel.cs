using Library.Common.ViewModels;
using Microsoft.AspNetCore.Http;
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
    public class ParkingModel
    {
        public IFormFile Image { get; set; }

        //Название парковки
        public string? Name { get; set; }

        //Адрес парковки
        public string Adress { get; set; }

        public static implicit operator ParkingEntityModel(ParkingModel model)
        {

            if (model == null)
            {

                return null;

            }
            else return new ParkingEntityModel
            {
                Adress = model.Adress,
                Name = model.Name,
            };
        }

        public static implicit operator ParkingModel(ParkingEntityModel model)
        {

            if (model == null)
            {

                return null;

            }
            else return new ParkingModel
            {
                Adress = model.Adress,
                Name = model.Name,
            };
        }

        public static implicit operator ParkingModel(ParkingViewModel model)
        {

            if (model == null)
            {

                return null;

            }
            else return new ParkingModel
            {
                Adress = model.Adress,
                Name = model.Name,
            };
        }
        public static implicit operator ParkingViewModel(ParkingModel model)
        {

            if (model == null)
            {

                return null;

            }
            else return new ParkingViewModel
            {
                Adress = model.Adress,
                Name = model.Name,
            };
        }

    }
}
