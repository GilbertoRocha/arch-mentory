using Hotline.Domain.Base;

namespace Hotline.Domain.Entities;

using Enum;

public class Ticket: BaseEntity
{
    public Guid ExternalId { get; init; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTimeOffset? ResolvedAt { get; private set; }
    public TicketStatus Status { get; private set; }
    
    // EF 7 or higher can use the contructor with parameter, if the parameter have the same name as the fields
    private Ticket(string title, string description, Guid externalId, TicketStatus status)
    {
        Title = title;
        Description = description;
        ExternalId = externalId;
        Status = status;
    }

    public static Ticket Create(string title, string description)
    {
        return new Ticket(title, description, Guid.CreateVersion7(), TicketStatus.New);
    }
}
