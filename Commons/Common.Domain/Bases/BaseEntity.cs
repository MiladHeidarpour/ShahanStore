namespace Common.Domain.Bases;

public class BaseEntity
{
    public Guid Id { get; protected set; }
    public DateTimeOffset CreationDate { get; protected set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTimeOffset.UtcNow;
    }
}