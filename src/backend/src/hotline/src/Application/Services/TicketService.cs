using Hotline.Application.Mappers.Outputs;
using Hotline.Application.Schemas.Input;
using Hotline.Application.Schemas.Output;
using Hotline.Domain.Entities;
using Hotline.Domain.Interfaces;

namespace Hotline.Application.Services;

public class TicketService(ITicketRepository ticketRepository)
{
    public async Task<IEnumerable<TicketOutput>> GetAllTicketsAsync(CancellationToken ct = default)
    {
        IEnumerable<Ticket> tickets = await ticketRepository.GetAllTicketsAsync();
        return tickets.ToOutput();
    }

    public async Task<TicketOutput> AddTicketAsync(NewTicketInput ticketInput, CancellationToken ct = default)
    {
        var ticket = Ticket.Create(ticketInput.Title, ticketInput.Description);
        Ticket savedTicket = await ticketRepository.AddTicketAsync(ticket, ct);
        
        return savedTicket.ToOutput();
    }

    public async Task UpdateTicketAsync(Ticket ticket)
    {
        await ticketRepository.UpdateTicketAsync(ticket);
    }

    public async Task DeleteTicketAsync(int id)
    {
        await ticketRepository.DeleteTicketAsync(id);
    }
}
