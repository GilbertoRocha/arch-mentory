namespace Hotline.WebApi.Extension.WebApi;

public static class EndpointSingleton
{
    public static IServiceCollection AddEndPointSingleton(this IServiceCollection services)
    {
        services.AddSingleton(TimeProvider.System);
        return services;
    }
}