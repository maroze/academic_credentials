
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParking.Data.Data
{
    class DesignTimeContextFactory : IDesignTimeDbContextFactory<ParkingContext>
    {
        public ParkingContext CreateDbContext(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebParking"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<ParkingContext>();
            builder.UseNpgsql(connectionString);

            return new ParkingContext(builder.Options);
        }
    }
}
