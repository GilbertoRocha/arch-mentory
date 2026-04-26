using Hotline.Domain.Enum;

namespace Hotline.WebApi.Schemas.Responses;

public record TicketResponse
{
    public Guid ExternalId { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public TicketStatus Status { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset? UpdatedAt { get; init; }
    public DateTimeOffset? ResolvedAt { get; init; }
}