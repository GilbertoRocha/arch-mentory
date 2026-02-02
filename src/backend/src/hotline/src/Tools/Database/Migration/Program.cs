using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Hotline.Infrastructure.Database;

Console.WriteLine("Applying Migrations...");

var services = new ServiceCollection();

_ = services.AddDbContext<AppDbContext>(options =>
	options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION"),
		x => x.MigrationsAssembly("Hotline.Infrastructure")));

var serviceProvider = services.BuildServiceProvider();

using var scope = serviceProvider.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

try
{
	await dbContext.Database.MigrateAsync();
	Console.WriteLine("Migrations applied");
}
catch (Exception ex)
{
	Console.WriteLine($"Error during migrations: {ex.Message}");
	Environment.Exit(1);
}


