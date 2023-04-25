using Library.Common.ViewModels;
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

        public ParkingContext(DbContextOptions<ParkingContext> options) : base(options)
        {
            Database.EnsureCreated(); // создаем базу данных при первом обращении
        }
        public DbSet<UserEntityModel> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegisterViewModel>().HasData(
                new RegisterViewModel { Email = "arturo@gmail.com", Password = "Arturo1972!" },
                new RegisterViewModel { Email = "queen@gmail.com", Password = "Mer2005dit?" },
                new RegisterViewModel { Email = "yantoples98@gmail.com", Password = "gjsfjss4554," },
                new RegisterViewModel { Email = "cutelaura07@gmail.com", Password = "la;ura785" },
                new RegisterViewModel { Email = "justinbest@gmail.com", Password = "just100?!" });
        }
    }
}
