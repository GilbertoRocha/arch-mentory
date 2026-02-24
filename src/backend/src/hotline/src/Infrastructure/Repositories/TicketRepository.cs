using Hotline.Domain.Entities;
using Hotline.Domain.Interfaces;
using Hotline.Domain.Shared;
using Hotline.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hotline.Infrastructure.Repositories;

public class TicketRepository(AppDbContext dbContext) : ITicketRepository
{
	public async Task<Result<Ticket>> AddTicketAsync(Ticket ticket, CancellationToken ct = default)
	{
		var entry = await dbContext.Tickets.AddAsync(ticket, ct);
		await dbContext.SaveChangesAsync(ct);
		return entry.Entity;
	}

	public async Task<Result<IEnumerable<Ticket>>> GetAllTicketsAsync(CancellationToken ct = default)
	{
		var tickets = await dbContext.Tickets.AsNoTracking().ToListAsync(ct);
		return tickets;
	}
}
