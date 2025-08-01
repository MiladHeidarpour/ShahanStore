namespace ShahanStore.Infrastructure.BackgroundJobs.Models;

public class OutboxMessage
{
    private OutboxMessage()
    {
    }

    public OutboxMessage(string type, string content)
    {
        Id = Guid.NewGuid();
        Type = type;
        Content = content;
        OccurredOnUtc = DateTimeOffset.UtcNow;
    }

    public Guid Id { get; private set; }
    public string Type { get; private set; } // نام کامل نوع رویداد
    public string Content { get; private set; } // خود رویداد به صورت JSON
    public DateTimeOffset OccurredOnUtc { get; private set; }
    public DateTimeOffset? ProcessedOnUtc { get; private set; } // زمان پردازش
    public string? Error { get; private set; }

    public void MarkAsProcessed()
    {
        ProcessedOnUtc = DateTimeOffset.UtcNow;
    }

    public void MarkAsFailed(string error)
    {
        Error = error;
    }
}