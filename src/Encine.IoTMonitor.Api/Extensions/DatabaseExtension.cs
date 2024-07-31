using Encine.IoTMonitor.Infrastructure.Adapters.Data;
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
                options.UseMongoDB(client, configuration.GetSection("MongoDb:Database").Value);
            });
        }
    }
}
