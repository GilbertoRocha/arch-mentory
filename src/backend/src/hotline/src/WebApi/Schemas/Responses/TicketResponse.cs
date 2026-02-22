using Hotline.Domain.Enum;

namespace Hotline.WebApi.Schemas.Responses;

public readonly record struct TicketResponse(
    Guid ExternalId, 
    string Title, 
    string Description,
    TicketStatus Status,
    DateTimeOffset CreatedAt,
    DateTimeOffset? UpdatedAt,
    DateTimeOffset? ResolvedAt);