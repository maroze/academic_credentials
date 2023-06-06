using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Data.Data;
using WebParking.Data.Entities;

namespace WebParking.Data.Repositories.Implementations
{
    public class BookingLotRepository : BaseRepository<UserLotEntityModel>, IBookingLotRepository
    {
        public BookingLotRepository(ParkingContext context) : base(context)
        {
        }
        
        public async Task<UserLotEntityModel> AddBook(UserLotEntityModel lot)
        { 
            return await InsertAsync(lot);
        }

        public async Task<UserLotEntityModel> DeleteBook(int lotId)
        {
            var result = await GetQuery().FirstOrDefaultAsync(i => i.UserLotId==lotId);
            return await DeleteAsync(result);
        }

        public IEnumerable<UserLotEntityModel> GetUserBooks(int userId)
        {
            return  GetAll().Where(u => u.IdUsers == userId).ToList();
        }

        public async Task<UserLotEntityModel> UpdateBook(UserLotEntityModel lot)
        {
            return await UpdateAsync(lot);
        }
        public async Task<UserLotEntityModel> GetBook(int id)
        {
            return await GetQuery().FirstOrDefaultAsync(b=> b.UserLotId==id);
        }
    }
}
