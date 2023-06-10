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
            return await InsertAsync(lot);
        }

        public async Task<LotEntityModel> DeleteLot(int lotId)
        {
            var result = await GetQuery()
               .FirstOrDefaultAsync(l=>l.LotId==lotId);
            return await DeleteAsync(result);
        }

        public async Task<LotEntityModel> GetLot(int lotId)
        {
            return await GetQuery().Include(p => p.Parks).FirstOrDefaultAsync(l => l.LotId == lotId);
        }

        public IEnumerable<LotEntityModel> GetLots(int idpark)
        {
            return GetAll().Where(u => u.IdParks == idpark).ToList();
        }

        public async Task<LotEntityModel> UpdateLot(LotEntityModel lot)
        {
            
            return await UpdateAsync(lot);
        }
    }
}
