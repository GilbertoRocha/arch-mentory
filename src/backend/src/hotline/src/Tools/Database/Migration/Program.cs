using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DotNetEnv;
using Hotline.Infrastructure.Database;

Console.WriteLine("Applying Migrations...");

Env.Load("./.env");

var services = new ServiceCollection();

Console.WriteLine(Environment.GetEnvironmentVariable("DB_CONNECTION"));

object value = services.AddDbContext<AppDbContext>(options =>
	options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION"),
		x => x.MigrationsAssembly("Hotline.Infrastructure")));



var serviceProvider = services.BuildServiceProvider();


using var scope = serviceProvider.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

try
{
	await dbContext.Database.MigrateAsync();
	Console.WriteLine("✅ Migrations applieds");
}
catch (Exception ex)
{
	Console.WriteLine($"❌ Error pallying migrations: {ex.Message}");
	Environment.Exit(1);
}


