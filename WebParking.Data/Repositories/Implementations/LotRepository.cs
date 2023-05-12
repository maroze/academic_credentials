using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Data.Data;
using WebParking.Data.Entities;

namespace WebParking.Data.Repositories.Implementations
{
    public class LotRepository : BaseRepository<LotEntityModel>, ILotRepository
    {
        public LotRepository(ParkingContext _userContext) : base(_userContext)
        {

        }

        public Task<LotEntityModel> AddLot(LotEntityModel lot)
        {
            Insert(lot);
            return Task.FromResult(lot);
        }

        public async Task<LotEntityModel> GetLot(int lotId)
        {
            var result = await GetQuery()
                .FirstOrDefaultAsync(l => l.LotId == lotId);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Парковочное место не найдено");
            }
        }

        public IEnumerable<LotEntityModel> GetLots()
        {
            return GetAll().ToList();
        }
    }
}
