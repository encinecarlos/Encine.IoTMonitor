using Asp.Versioning;
using System.Diagnostics.CodeAnalysis;

namespace Encine.IoTMonitor.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerExtension
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                
                options.AssumeDefaultVersionWhenUnspecified = true;
                
                options.DefaultApiVersion = new ApiVersion(1, 0);
                
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("x-api-version"),
                    new MediaTypeApiVersionReader("x-api-version"));
            }).AddApiExplorer(opt =>
            {
                opt.GroupNameFormat = "'v'VVV";
                
                opt.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
