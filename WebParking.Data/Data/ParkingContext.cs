using Microsoft.AspNetCore.Identity;
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
            //Database.EnsureCreated(); // создаем базу данных при первом обращении

        }
        public DbSet<UserEntityModel> Users { get; set; }
        public DbSet<ParkingEntityModel> Parkings { get; set; }
        public DbSet<LotEntityModel> Lots { get; set; }
        public DbSet<UserLotEntityModel> UserLots { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LotEntityModel>()
            .HasOne(p => p.Parks)
            .WithMany(t => t.Lots)
            .HasForeignKey(p => p.IdParks);

            modelBuilder.Entity<UserLotEntityModel>()
            .HasOne(p => p.Lots)
            .WithMany(t => t.UserLots)
            .HasForeignKey(p => p.IdLots);

            modelBuilder.Entity<UserLotEntityModel>()
              .HasOne(p => p.Users)
              .WithMany(t => t.UserLots)
              .HasForeignKey(p => p.IdUsers);

        }
    }
}
