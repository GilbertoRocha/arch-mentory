using Hotline.Application.Mappers.Outputs;
using Hotline.Application.Schemas.Input;
using Hotline.Application.Schemas.Output;
using Hotline.Domain.Entities;
using Hotline.Domain.Interfaces;
using Hotline.Domain.Shared;
using Hotline.Domain.Specifications.Tickets;

namespace Hotline.Application.Services;

public class TicketService(IRepository<Ticket> repository)
{
    public async Task<Result<IEnumerable<TicketOutput>>> GetAllTicketsAsync(CancellationToken ct = default)
    {
        var activeSpec = new ActiveTicketsSpec();
        
        var repoTickets = await repository.ListAsync(activeSpec, ct);

        return repoTickets.ToOutput();
    }

    public async Task<Result<TicketOutput>> AddTicketAsync(NewTicketInput ticketInput, CancellationToken ct = default)
    {
        var ticket = Ticket.Create(ticketInput.Title, ticketInput.Description);
        
        await repository.AddAsync(ticket, ct);
        var affectedRows = await repository.SaveChangesAsync(ct);

        if (affectedRows == 0 && ticket.Id == 0)
            return Result<TicketOutput>.Failure("Error saving ticket");

        return Result<TicketOutput>.Success(ticket.ToOutput());
        
    }
}
