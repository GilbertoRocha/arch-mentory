namespace Hotline.Domain.Entities;

using Enum;

public class Ticket
{
    public int Id { get; private set; }
    public Guid ExternalId { get; init; }
    public string Title { get; private set; } = "";
    public string Description { get; private set; } = "";
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? ResolvedAt { get; private set; }
    public TicketStatus Status { get; private set; }
    
    private Ticket () {}

    internal Ticket(string title, string description)
    {
        ExternalId = Guid.NewGuid();
        Title = title;
        Description = description;
        CreatedAt = DateTime.UtcNow;
        Status = TicketStatus.New;
    }
}
