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
        public DbSet<SignUpViewModel> Users { get; set; }
        public ParkingContext(DbContextOptions<ParkingContext> options) : base(options)
        {
            Database.EnsureCreated(); // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SignUpViewModel>().HasData(new SignUpViewModel
            {
                LastName = "Arturo",
                Email = "arturo@gmail.com",
                Password = "Arturo1972!"
            },
                new SignUpViewModel { LastName = "Meredit", Email = "queen@gmail.com", Password = "Mer2005dit?" },
                new SignUpViewModel { LastName = "Yan", Email = "yantoples98@gmail.com", Password = "gjsfjss4554," },
                new SignUpViewModel { LastName = "Laura", Email = "cutelaura07@gmail.com", Password = "la;ura785" },
                new SignUpViewModel { LastName = "Justin", Email = "justinbest@gmail.com", Password = "just100?!" }
                );
        }
    }
}
