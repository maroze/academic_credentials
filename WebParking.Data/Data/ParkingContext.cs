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
        public DbSet<UserEntityModel> Users { get; set; }
        public ParkingContext(DbContextOptions<ParkingContext> options) : base(options)
        {
            Database.EnsureCreated(); // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntityModel>().HasData(
                new UserEntityModel { Id = Guid.NewGuid(), Email = "arturo@gmail.com", Password = "Arturo1972!", Role = Role.User },
                new UserEntityModel { Id = Guid.NewGuid(), Email = "queen@gmail.com", Password = "Mer2005dit?", Role = Role.User },
                new UserEntityModel { Id = Guid.NewGuid(), Email = "yantoples98@gmail.com", Password = "gjsfjss4554,", Role = Role.User },
                new UserEntityModel { Id = Guid.NewGuid(), Email = "cutelaura07@gmail.com", Password = "la;ura785", Role = Role.Administrator },
                new UserEntityModel { Id = Guid.NewGuid(), Email = "justinbest@gmail.com", Password = "just100?!", Role = Role.Manager });
        }
    }
}
