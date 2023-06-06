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
            return await InsertAsync(park);
        }

        public async Task<ParkingEntityModel> DeleteParking(int parkingId)
        {
            var result = await GetQuery().FirstOrDefaultAsync(i => i.ParkId == parkingId);
            return await DeleteAsync(result);
        }

        public async Task<ParkingEntityModel> GetParking(int parkId)
        {
            return await GetQuery()
                  .FirstOrDefaultAsync(p => p.ParkId == parkId);
        }

        public IEnumerable<ParkingEntityModel> GetParkins()
        {
            return GetAll().ToList();
        }

        public async Task<ParkingEntityModel> UpdateParking(ParkingEntityModel parking)
        {
            return await UpdateAsync(parking);
        }
    }
}
