using Asp.Versioning;

namespace Hotline.WebApi.Extension.WebApi;

public static class VersionExtension
{
    public static IServiceCollection AddDefaultApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true; 
                options.ApiVersionReader = new UrlSegmentApiVersionReader(); 
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV"; 
                options.SubstituteApiVersionInUrl = true;
            }); 
        return services;
    }
    
}