using Encine.IoTMonitor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Encine.IoTMonitor.Infrastructure.Adapters.Data
{
    public class DataContext : DbContext
    {
        //public static DataContext Create(IMongoDatabase database)
        //{
        //    return new(new DbContextOptionsBuilder<DataContext>()
        //        .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
        //        .Options);
        //}

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sensor>().ToCollection("sensors");
            modelBuilder.Entity<SensorData>().ToCollection("sensorData");
            modelBuilder.Entity<SensorConfiguration>().ToCollection("deviceConfigurations");
        }

        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorData> SensorData { get; set; }
        public DbSet<SensorConfiguration> DeviceConfigurations { get; set; }
    }
    
}
