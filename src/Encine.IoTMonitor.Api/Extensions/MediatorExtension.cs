using Encine.IoTMonitor.UseCases.SensorUseCase.Commands;
using System.Diagnostics.CodeAnalysis;

namespace Encine.IoTMonitor.Api.Extensions
{
    [ExcludeFromCodeCoverage]
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
