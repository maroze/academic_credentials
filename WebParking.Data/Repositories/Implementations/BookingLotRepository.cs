using System;
using Microsoft.EntityFrameworkCore;
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
        { }

        public async Task<UserLotEntityModel> AddBook(UserLotEntityModel lot)
        {
            var curbook = GetQuery().Where(b => b.IdLots == lot.IdLots &&
        (lot.StartBookedTime <= b.EndBookedTime && lot.StartBookedTime >= b.StartBookedTime ||
         b.StartBookedTime <= lot.EndBookedTime && b.StartBookedTime >= lot.StartBookedTime))
                .FirstOrDefault();
            if (curbook!=null)
            {
                return null;
            }
            return await InsertAsync(lot);
        }

        public async Task<UserLotEntityModel> DeleteBook(int lotId)
        {
            var result = await GetQuery().FirstOrDefaultAsync(i => i.UserLotId == lotId);
            return await DeleteAsync(result);
        }

        public IEnumerable<UserLotEntityModel> GetUserBooks(int id)
        {
            return GetAll().Where(t => t.IdUsers == id).ToList();
        }

        public async Task<UserLotEntityModel> GetBook(int id)
        {
            return await GetQuery().FirstOrDefaultAsync(b => b.UserLotId == id);
        }

        public IEnumerable<UserLotEntityModel> GetStartBooks()
        {
            return GetAll().Where(t => !t.IsExpired && DateTime.Now.AddMinutes(1) > t.StartBookedTime && DateTime.Now.AddMinutes(-1) < t.StartBookedTime).ToList();
        }

        public IEnumerable<UserLotEntityModel> GetEndBooks()
        {
            return GetAll().Where(t => !t.IsExpired && DateTime.Now > t.EndBookedTime).ToList();
        }

        public async Task<UserLotEntityModel> UpdateBook(UserLotEntityModel lot)
        {
            return await UpdateAsync(lot);
        }
    }
}
