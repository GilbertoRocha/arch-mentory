using Ardalis.Specification;
using Hotline.Domain.Entities;

namespace Hotline.Domain.Specifications.Tickets;

public class ActiveTicketsSpec : Specification<Ticket>
{
    public ActiveTicketsSpec() : this(true)
    {
    }
    
    public ActiveTicketsSpec(bool readOnly)
    {
        Query
            .IsActive();
        
        if (readOnly)
            Query.AsNoTracking();
    }
}