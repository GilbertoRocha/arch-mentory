using Hotline.Domain.Entities;
using Hotline.Domain.Interfaces;
using Hotline.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hotline.Infrastructure.Repositories;

public class TicketRepository(AppDbContext dbContext) : ITicketRepository
{
	public async Task<Ticket> AddTicketAsync(Ticket ticket, CancellationToken ct = default)
	{
		var entry = await dbContext.Tickets.AddAsync(ticket, ct);
		await dbContext.SaveChangesAsync(ct);
		return entry.Entity;
	}

	public Task DeleteTicketAsync(int id)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Ticket>> GetAllTicketsAsync(CancellationToken ct = default)
	{
		return await dbContext.Tickets.ToListAsync(ct);
	}

	public Task UpdateTicketAsync(Ticket ticket)
	{
		throw new NotImplementedException();
	}
}
