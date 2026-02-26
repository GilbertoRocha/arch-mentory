using Hotline.Domain.Enum;

namespace Hotline.Application.Schemas.Output;

public readonly record struct TicketOutput(
    Guid ExternalId, 
    string Title, 
    string Description,
    TicketStatus Status,
    DateTimeOffset CreatedAt,
    DateTimeOffset? UpdatedAt,
    DateTimeOffset? ResolvedAt);
