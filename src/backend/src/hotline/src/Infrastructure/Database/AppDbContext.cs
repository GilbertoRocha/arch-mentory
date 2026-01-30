using Hotline.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotline.Infrastructure.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
	public DbSet<Ticket> Tickets => Set<Ticket>();
	
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
	}
}
