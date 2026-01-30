using Hotline.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hotline.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<TicketService>();
        return services;
    }
    
}