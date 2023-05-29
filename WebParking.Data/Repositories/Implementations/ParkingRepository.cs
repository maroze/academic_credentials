using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common;
using WebParking.Common.ViewModels;
using WebParking.Data.Data;
using WebParking.Data.Entities;

namespace WebParking.Data.Repositories.Implementations
{
    public class ParkingRepository : BaseRepository<ParkingEntityModel>, IParkingRepository
    {
        public ParkingRepository(ParkingContext _userContext) : base(_userContext)
        {

        }

        public async Task<ParkingEntityModel> AddParking(ParkingEntityModel park)
        {
            ParkingEntityModel parking = new ParkingEntityModel() { Adress = park.Adress, Name = park.Name, Image = park.Image};
            Insert(parking);
            return parking;
        }

        public async Task<ParkingEntityModel> GetParking(int parkId)
        {
            var result = await GetQuery()
                  .FirstOrDefaultAsync(p => p.ParkId == parkId);

            return result;
        }
    }
}
