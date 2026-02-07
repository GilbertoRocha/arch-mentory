namespace Hotline.WebApi.Extension.Dev;

public static class CorsExtensions
{
    private const string DevCorsPolicy = "DevCorsPolicy";
    public static IServiceCollection AddDevCors(this IServiceCollection services, IHostEnvironment env)
    {
        if (!env.IsDevelopment())
            return services;
        
        services.AddCors(options => 
        {
            options.AddPolicy(DevCorsPolicy, policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
        return services;
    }

    public static IApplicationBuilder UseDevCors(this IApplicationBuilder app, IHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseCors(DevCorsPolicy);

        return app;
    }
    
}