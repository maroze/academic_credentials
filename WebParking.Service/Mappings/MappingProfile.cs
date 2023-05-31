using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels.Auth;
using WebParking.Common.ViewModels.LotParking;
using WebParking.Common.ViewModels.Parking;
using WebParking.Data.Entities;
using WebParking.Service.Models;

namespace WebParking.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntityModel, UserModel>().ReverseMap();
            CreateMap<UserModel, LoginViewModel>();
            CreateMap<UserModel, ForgotPasswordViewModel>();
            CreateMap<UserModel, ResetPasswordViewModel>();

            CreateMap<ParkingModel, ParkingViewModel>().ReverseMap();
            CreateMap<ParkingEntityModel, ParkingModel>().ReverseMap();

            CreateMap<LotModel, LotViewModel>().ReverseMap();
            CreateMap<LotEntityModel, LotModel>().ReverseMap();
        }
    }
}
