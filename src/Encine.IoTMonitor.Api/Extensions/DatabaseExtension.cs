﻿using Encine.IoTMonitor.Infrastructure.Adapters.Data;
using Encine.IoTMonitor.UseCases.Ports;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Encine.IoTMonitor.Api.Extensions
{
    public static class DatabaseExtension
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));

            services.AddDbContext<DataContext>(options =>
            {
                var database = configuration.GetSection("DefaultConnectionString:Database");
                options.UseMongoDB(client, configuration.GetSection("Database").Value);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
