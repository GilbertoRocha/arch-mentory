using Hotline.Domain.Entities;

namespace Hotline.Domain.Interfaces;

public interface ITicketRepository
{
    Task<IEnumerable<Ticket>> GetAllTicketsAsync(CancellationToken ct = default);
    Task<Ticket> AddTicketAsync(Ticket ticket, CancellationToken ct = default);
    Task UpdateTicketAsync(Ticket ticket);
    Task DeleteTicketAsync(int id);

}
