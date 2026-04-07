using Ardalis.Specification;
using Hotline.Domain.Entities;
using Hotline.Domain.Enum;

namespace Hotline.Domain.Specifications.Tickets;

internal static class TicketsCriteriaExtensions
{
    private static readonly TicketStatus[] ActiveStatus = [TicketStatus.New, TicketStatus.InProgress];
    
    internal static ISpecificationBuilder<Ticket> IsActive(this ISpecificationBuilder<Ticket> specification)
    {
        return specification.Where(t => ActiveStatus.AsEnumerable().Contains(t.Status));
    }
}