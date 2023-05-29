using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common;
using WebParking.Common.ViewModels;
using WebParking.Data.Entities;
using WebParking.Data.Repositories;
using WebParking.Service.Models;

namespace WebParking.Service.Services.Implementations
{
    public class LotService : ILotService
    {
        private readonly ILotRepository _lotRepository;

        private readonly IParkingRepository _parkRepository;
        public LotService(ILotRepository lotRepository, IParkingRepository parkRepository)
        {
            _lotRepository = lotRepository;
            _parkRepository = parkRepository;
        }

        public async Task<LotModel> AddLot(LotViewModel lot, int idpark)
        {
            if (lot == null)
                throw new Exception("Парк место не указано");
            
                var result = await _lotRepository.AddLot(lot);
                result.IdParks = idpark;
                return result;
        }

        public async Task<LotModel> BookLot(int lotId)
        {
            if (lotId == null)
                throw new Exception("Парк место не указано");

            var result = await _lotRepository.BookLot(lotId);
            if (result != null)
            {
                result.IsBooked = true;
                return result;
            }
            else
                return null;

        }

        public async Task<LotModel> GetLot(int lotId)
        {
            if (lotId == null)
                throw new Exception("Парк место не указано");
            var result = _lotRepository.GetLot(lotId);
            if (result == null)
            {
                throw new Exception("Парк место не существует");
            }
            return await result;
        }

        public IEnumerable<LotModel> GetLots()
        {
            List<LotModel> result = new List<LotModel>();
            var lot_list = _lotRepository.GetLots();
            foreach (var c in lot_list)
            {

                result.Add(c);
            }

            return result;
        }
    }
}
