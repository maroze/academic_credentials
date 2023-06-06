﻿using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common;
using WebParking.Common.ViewModels;
using WebParking.Common.ViewModels.LotParking;
using WebParking.Data.Entities;
using WebParking.Data.Repositories;
using WebParking.Service.Models;

namespace WebParking.Service.Services.Implementations
{
    public class LotService : ILotService
    {
        private readonly ILotRepository _lotRepository;
        private readonly IParkingRepository _parkRepository;
        private readonly IMapper _mapper;

        public LotService(ILotRepository lotRepository, IParkingRepository parkRepository, IMapper mapper)
        {
            _lotRepository = lotRepository;
            _parkRepository = parkRepository;
            _mapper = mapper;
        }

        public async Task<LotModel> AddLot(LotViewModel lot)
        {
             if (lot == null)
                throw new Exception("Парк место не указано");
             if (await _parkRepository.GetParking(lot.ParkId) == null)
                throw new Exception("Парковки не существует");

            return _mapper.Map<LotModel>(await _lotRepository.AddLot(_mapper.Map<LotEntityModel>(lot)));
        }

        public async Task<LotModel> DeleteLot(int lotId)
        {
            if (lotId == null)
                throw new Exception("Id места не указано");

            return _mapper.Map<LotModel>(await _lotRepository.DeleteLot(lotId));
        }

        public async Task<LotModel> GetLot(int lotId)
        {
            if (lotId == null)
                throw new Exception("Парк место не указано");
            var result = await _lotRepository.GetLot(lotId);
            if (result == null)
                throw new Exception("Парк место не существует");
            return _mapper.Map<LotModel>(result);
        }

        public IEnumerable<LotModel> GetLots(int parkId)
        {
            var lot_list = _lotRepository.GetLots(parkId);
            return _mapper.Map<IEnumerable<LotModel>>(lot_list);
        }

        public async Task<LotModel> UpdateLot(LotUpdateViewModel lot)
        {
            var res = await _lotRepository.GetLot(lot.LotId); 
            if (res == null)
                throw new Exception("Место не существует");
            res = _mapper.Map <LotEntityModel > (lot);
            return _mapper.Map<LotModel>(await _lotRepository.UpdateLot(res));
        }
    }
}
