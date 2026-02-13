using Hotline.Domain.Interfaces;
using Hotline.Infrastructure.Database;
using Hotline.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hotline.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION")));
        services.AddScoped<ITicketRepository, TicketRepository>();

        return services;
    }
    
}