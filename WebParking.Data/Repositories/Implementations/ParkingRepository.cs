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

        public Task<ParkingEntityModel> AddParking(ParkingViewModel park)
        {
            ParkingEntityModel parkem = new ParkingEntityModel() { Adress = park.Adress, Name = park.Name };
            byte[] imageData = null;
            using (var binaryReader = new BinaryReader(park.Image.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)park.Image.Length);
            }
            parkem.Image = imageData;

            Insert(parkem);
            return Task.FromResult(parkem);
        }

        public async Task<ParkingEntityModel> GetParking(int parkId)
        {
            var result = await GetQuery()
                  .FirstOrDefaultAsync(p => p.ParkId == parkId);

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Парковка не найдена");
            }
        }
    }
}
