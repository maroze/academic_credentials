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
        public DbSet<ParkingEntityModel> Parkings { get; set; }
        public DbSet<LotEntityModel> Lots { get; set; }
        public DbSet<UserLotEntityModel> UserLots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       //     modelBuilder.Entity<ParkingEntityModel>()
       // .ToTable("Parkings");
       //     modelBuilder.Entity<ParkingEntityModel>()
       //.HasData(
       //         new ParkingEntityModel
       //         {
       //             ParkId = 1,
       //             Name = "name1",
       //             Adress = "adress",
       //             Image = ""
       //         });
       //     modelBuilder.Entity<LotEntityModel>()
       //   .ToTable("Lots");
       //     modelBuilder.Entity<LotEntityModel>()
       //.HasData(
       //         new LotEntityModel
       //         {
       //             LotId = 1,
       //             Name = "name1",
       //             IsBlocked = false,
       //             IsBooked = false,
       //             IdParks = Parkings.Single(s => s.ParkId == 1).ParkId
       //         });
        }
    }
}
