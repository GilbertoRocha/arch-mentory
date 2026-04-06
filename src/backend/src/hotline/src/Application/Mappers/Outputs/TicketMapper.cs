using Hotline.Application.Schemas.Output;
using Hotline.Domain.Entities;

namespace Hotline.Application.Mappers.Outputs;

public static class TicketMapper
{
    public static List<TicketOutput> ToOutput(this List<Ticket> tickets)
    {
        return tickets.Select(ToOutput).ToList();
    }

    public static TicketOutput ToOutput(this Ticket ticket)
    {
        return new TicketOutput(
            ExternalId: ticket.ExternalId,
            Title: ticket.Title, 
            Description: ticket.Description,
            Status: ticket.Status,
            CreatedAt: ticket.CreatedAt,
            UpdatedAt: ticket.UpdatedAt,
            ResolvedAt: ticket.ResolvedAt);
    }
}