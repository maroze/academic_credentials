using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common;
using WebParking.Common.ViewModels.Parking;
using WebParking.Data.Entities;
using WebParking.Data.Repositories;
using WebParking.Data.Repositories.Implementations;
using WebParking.Service.Models;

namespace WebParking.Service.Services.Implementations
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingRepository _parkRepository;
        private readonly IMapper _mapper;
        public ParkingService(IParkingRepository parkRepository, IMapper mapper)
        {
            _parkRepository=parkRepository;
            _mapper = mapper;
        }
        public async Task<ParkingModel> AddParking(ParkingViewModel park)
        {
            if (park == null)
                throw new Exception("Парковка не указана");

            ParkingEntityModel parking = new ParkingEntityModel() { Adress = park.Adress, Name = park.Name };
            byte[] imageData = null;
            using (var binaryReader = new BinaryReader(park.Image.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)park.Image.Length);
            }
            parking.Image = imageData;

            return _mapper.Map<ParkingModel>(await _parkRepository.AddParking(parking));
        }

        public async Task<ParkingModel> GetParking(int parkId)
        {
            if (parkId == null)
                throw new Exception("Id парковки не указан");

            var result = await _parkRepository.GetParking(parkId);

            if (result == null)
            {
                throw new Exception("Парковки не существует");
            }
            return _mapper.Map<ParkingModel>(result);
        }
    }
}
