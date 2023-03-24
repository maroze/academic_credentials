using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParking.Data.Entities;

namespace WebParking.Data.Data
{
    public class ParkingContext : DbContext
    {
        public DbSet<UserEntityModel> Users { get; set; }
        public ParkingContext(DbContextOptions<ParkingContext> options) : base(options)
        {
            Database.EnsureCreated(); // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntityModel>().HasData(new UserEntityModel
            {
                Id = 1,
                Name = "Arturo",
                Email = "arturo@gmail.com",
                Password = "Arturo1972!"
            },
                new UserEntityModel { Id = 2, Name = "Meredit", Email = "queen@gmail.com", Password = "Mer2005dit?" },
                new UserEntityModel { Id = 3, Name = "Yan", Email = "yantoples98@gmail.com", Password = "gjsfjss4554," },
                new UserEntityModel { Id = 4, Name = "Laura", Email = "cutelaura07@gmail.com", Password = "la;ura785" },
                new UserEntityModel { Id = 5, Name = "Justin", Email = "justinbest@gmail.com", Password = "just100?!" }
                );
        }
    }
}
