using Hotline.Application.Mappers.Outputs;
using Hotline.Application.Schemas.Input;
using Hotline.Application.Schemas.Output;
using Hotline.Domain.Entities;
using Hotline.Domain.Interfaces;
using Hotline.Domain.Shared;

namespace Hotline.Application.Services;

public class TicketService(ITicketRepository ticketRepository)
{
    public async Task<Result<IEnumerable<TicketOutput>>> GetAllTicketsAsync(CancellationToken ct = default)
    {
        var repoTickets = await ticketRepository.GetAllTicketsAsync(ct);

        return repoTickets.Map(ticket => ticket.ToOutput());
    }

    public async Task<Result<TicketOutput>> AddTicketAsync(NewTicketInput ticketInput, CancellationToken ct = default)
    {
        var ticket = Ticket.Create(ticketInput.Title, ticketInput.Description);
        var savedTicket = await ticketRepository.AddTicketAsync(ticket, ct);

        return savedTicket.Map(saved => saved.ToOutput());
    }
}
