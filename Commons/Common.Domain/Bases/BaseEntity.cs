namespace Common.Domain.Bases;

public class BaseEntity
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTimeOffset.UtcNow;
    }

    public Guid Id { get; protected set; }
    public DateTimeOffset CreationDate { get; protected set; }
}