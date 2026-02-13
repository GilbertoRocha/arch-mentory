namespace Hotline.Domain.Base;

public abstract class BaseEntity
{
    public int Id { get; protected set; }
    public DateTimeOffset CreatedAt { get; init; } = TimeProvider.System.GetUtcNow();
    public DateTimeOffset? UpdatedAt { get; protected set; }
}