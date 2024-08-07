using Encine.IoTMonitor.UseCases.SensorUseCase;
using System.Reflection;

namespace Encine.IoTMonitor.Api.Extensions
{
    public static class MediatorExtension
    {
        public static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(opt =>
            {
                opt.RegisterServicesFromAssembly(typeof(SensorHandlerUseCase).Assembly);
            });
        }
    }
}
