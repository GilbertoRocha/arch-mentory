using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Hotline.Infrastructure.Database;
using Hotline.Infrastructure.DependencyInjection;
using Hotline.Tool.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;


ConsoleColorized.Step("Loading Configurations...");

var config = new ConfigurationBuilder()
	.AddEnvironmentVariables() 
	.LoadEnvValues()           
	.Build();

var services = new ServiceCollection();

_ = services.AddDbContext<AppDbContext>(options =>
	options.UseNpgsql(config["DB-CONNECTION"],
		x => x.MigrationsAssembly("Hotline.Infrastructure")));

var serviceProvider = services.BuildServiceProvider();

using var scope = serviceProvider.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

var appliedMigrations = await dbContext.Database.GetAppliedMigrationsAsync();
var lastStableMigration = appliedMigrations.LastOrDefault();
try
{
	ConsoleColorized.Step("Applying Migrations...");
	await dbContext.Database.MigrateAsync();
	ConsoleColorized.Success("Migrations applied");
}
catch (Exception ex)
{
	ConsoleColorized.Error($"Error during migrations: {ex.Message}");
	ConsoleColorized.Step("Looking for avaliable rollback");
	
	if (lastStableMigration == null)
	{
		ConsoleColorized.Warning("No stable version to rollback");
		Environment.Exit(1);
	}

	ConsoleColorized.Step($"Starting the rollback for {lastStableMigration}");
	try
	{
		var migrator = dbContext.Database.GetService<Microsoft.EntityFrameworkCore.Migrations.IMigrator>();
		await migrator.MigrateAsync(lastStableMigration);
		ConsoleColorized.Success("Rollback executed");
	}
	catch (Exception e)
	{
		ConsoleColorized.Error($"Error during rollback: {e.Message}");
	}
	Environment.Exit(1);
}


