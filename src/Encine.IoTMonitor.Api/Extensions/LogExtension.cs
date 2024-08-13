using Serilog;
using Serilog.Events;
using System.Diagnostics.CodeAnalysis;

namespace Encine.IoTMonitor.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class LogExtension
    {
        public static void AddSerilogExtension(this IServiceCollection services)
        {
            services.AddSerilog(opt =>
            {
                opt.MinimumLevel.Verbose()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .MinimumLevel.Override("System", LogEventLevel.Warning)
                    .Enrich.FromLogContext()
                    .WriteTo.Console();
            });
        }
    }
}
