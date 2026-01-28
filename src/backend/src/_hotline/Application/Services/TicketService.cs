namespace Hotline.Application.Services;

using Domain.Entities;
using Domain.Interfaces;
using Hotline.Application.Schema.DTO;

public class TicketService(ITicketRepository ticketRepository)
{
    private readonly ITicketRepository ticketRepository = ticketRepository;

    public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
    {
        return await ticketRepository.GetAllTicketsAsync();
    }

    public async Task<Guid> AddTicketAsync(NewTicketDTO ticketDto)
    {
        Ticket ticket = Ticket.NewTicket(ticketDto.Title, ticketDto.Description);

        return await ticketRepository.AddTicketAsync(ticket);
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
