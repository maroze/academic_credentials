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
            modelBuilder.Entity<UserEntityModel>().Property(u => u.Role).HasDefaultValue(2); 
        }
    }
}
