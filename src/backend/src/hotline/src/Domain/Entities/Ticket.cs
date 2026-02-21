using Hotline.Domain.Base;

namespace Hotline.Domain.Entities;

using Enum;

public class Ticket: BaseEntity
{
    public Guid ExternalId { get; init; }
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public DateTimeOffset? ResolvedAt { get; private set; }
    public TicketStatus Status { get; private set; }
    
    private Ticket() { }
    
    private Ticket(string title, string description, Guid externalId, TicketStatus status)
    {
        Title = title;
        Description = description;
        ExternalId = externalId;
        Status = status;
    }

    internal static Ticket Create(string title, string description)
    {
        return new Ticket(title, description, Guid.CreateVersion7(), TicketStatus.New);
    }
}
