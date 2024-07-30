using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.SystemConsole.Themes;

namespace Encine.IoTMonitor.Api.Extensions
{
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
