using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Common.ViewModels;
using WebParking.Data.Data;
using WebParking.Data.Entities;

namespace WebParking.Data.Repositories.Implementations
{
    public class LotRepository : BaseRepository<LotEntityModel>, ILotRepository
    {
        public LotRepository(ParkingContext _userContext) : base(_userContext)
        {

        }

        public async Task<LotEntityModel> AddLot(LotEntityModel lot)
        {
            Insert(lot);
            return lot;
        }
        
        public async Task<LotEntityModel> BookLot(int lotId)
        {
            var result = await GetQuery().Include(p => p.Parks)
                .FirstOrDefaultAsync(l => l.LotId == lotId);
            if (!result.IsBooked)
            {
                return result;
            }
            else
                return null;

            
        }

        public async Task<LotEntityModel> GetLot(int lotId)
        {
            var result = await GetQuery().Include(p => p.Parks)
                .FirstOrDefaultAsync(l => l.LotId == lotId);
            return result;
        }

        public IEnumerable<LotEntityModel> GetLots()
        {
            return GetAll().ToList();
        }
    }
}
