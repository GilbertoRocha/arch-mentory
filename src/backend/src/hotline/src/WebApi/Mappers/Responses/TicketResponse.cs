using Hotline.Domain.Enum;

namespace Hotline.WebApi.Mappers.Responses;

public readonly record struct TicketResponse(
    Guid ExternalId, 
    string Title, 
    string Description,
    TicketStatus Status,
    DateTimeOffset CreatedAt,
    DateTimeOffset? UpdatedAt,
    DateTimeOffset? ResolvedAt);