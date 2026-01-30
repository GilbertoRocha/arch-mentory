using Hotline.Domain.Factories;

namespace Hotline.Application.Services;

using Domain.Entities;
using Domain.Interfaces;
using Schema.DTO;

public class TicketService(ITicketRepository ticketRepository)
{
    public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
    {
        return await ticketRepository.GetAllTicketsAsync();
    }

    public async Task<Guid> AddTicketAsync(NewTicketDTO ticketDto)
    {
        var ticket = TicketFactory.New(ticketDto.Title, ticketDto.Description);

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
