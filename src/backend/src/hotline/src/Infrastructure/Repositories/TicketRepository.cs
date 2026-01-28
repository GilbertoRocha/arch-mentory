using Hotline.Domain.Entities;
using Hotline.Domain.Interfaces;
using Hotline.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hotline.Infrastructure.Repositories;

public class TicketRepository(AppDbContext dbContext) : ITicketRepository
{
	public async Task<Guid> AddTicketAsync(Ticket ticket)
	{
		dbContext.Tickets.Add(ticket);
		await dbContext.SaveChangesAsync();
		return ticket.ExternalId;
	}

	public Task DeleteTicketAsync(int id)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
	{
		return await dbContext.Tickets.ToListAsync();
	}

	public Task UpdateTicketAsync(Ticket ticket)
	{
		throw new NotImplementedException();
	}
}
