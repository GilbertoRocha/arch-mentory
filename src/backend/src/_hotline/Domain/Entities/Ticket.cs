namespace Hotline.Domain.Entities;

using Enum;

public class Ticket
{
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public TicketStatus Status { get; set; }

    public static Ticket NewTicket(string title, string description)
    {
        return new Ticket
        {
            ExternalId = Guid.NewGuid(),
            Title = title,
            Description = description,
            CreatedAt = DateTime.UtcNow,
            Status = TicketStatus.New
        };
    }

}
