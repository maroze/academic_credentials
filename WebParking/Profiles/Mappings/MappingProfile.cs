using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels.Auth;
using WebParking.Common.ViewModels.Booking;
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
            CreateMap<UserModel, LoginViewModel>().ReverseMap();
            CreateMap<UserEntityModel, LoginViewModel>().ReverseMap();
            CreateMap<UserModel, ForgotPasswordViewModel>();
            CreateMap<ForgotPasswordViewModel, UserEntityModel>();
            CreateMap<UserModel, ResetPasswordViewModel>();
            CreateMap<UserModel, RegisterViewModel>();
            CreateMap<UserViewModel, UserEntityModel>().ReverseMap(); 
            CreateMap<UserEntityModel, ProfileUserViewModel>().ReverseMap();

            CreateMap<ParkingModel, ParkingViewModel>().ReverseMap();
            CreateMap<ParkingEntityModel, ParkingModel>().ReverseMap();
            CreateMap<ParkingEntityModel, ParkingUpdateViewModel>().ReverseMap();

            CreateMap<LotModel, LotViewModel>().ReverseMap();
            CreateMap<LotEntityModel, LotModel>().ReverseMap();
            CreateMap<LotViewModel, LotEntityModel>().ReverseMap();
            CreateMap<LotUpdateViewModel, LotEntityModel>();

            CreateMap<UserLotEntityModel, BookModel>().ReverseMap();
            CreateMap<UserLotEntityModel, BookingViewModel>().ReverseMap();
            CreateMap<UserLotEntityModel, ChangeBookingViewModel>().ReverseMap();
            CreateMap<BookModel, BookingViewModel>().ReverseMap();
            CreateMap<BookModel, ChangeBookingViewModel>().ReverseMap();

        }
    }
}
