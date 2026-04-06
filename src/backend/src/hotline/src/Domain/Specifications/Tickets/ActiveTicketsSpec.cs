using Ardalis.Specification;
using Hotline.Domain.Entities;
using Hotline.Domain.Enum;

namespace Hotline.Domain.Specifications.Tickets;

public class ActiveTicketsSpec : Specification<Ticket>
{
    public ActiveTicketsSpec(bool asNoTracking = true)
    {
        Query
            .WhereIsActive();
        
        if (asNoTracking)
            Query.AsNoTracking();
            
    }
}