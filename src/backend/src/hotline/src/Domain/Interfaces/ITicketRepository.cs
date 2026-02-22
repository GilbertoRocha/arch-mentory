using Hotline.Domain.Entities;
using Hotline.Domain.Shared;

namespace Hotline.Domain.Interfaces;

public interface ITicketRepository
{
    Task<Result<IEnumerable<Ticket>>> GetAllTicketsAsync(CancellationToken ct = default);
    Task<Result<Ticket>> AddTicketAsync(Ticket ticket, CancellationToken ct = default);
    Task UpdateTicketAsync(Ticket ticket);
    Task DeleteTicketAsync(int id);

}
