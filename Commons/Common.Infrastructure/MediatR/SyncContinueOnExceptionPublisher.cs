using MediatR;

namespace Common.Infrastructure.MediatR;

public class SyncContinueOnExceptionPublisher : INotificationPublisher
{
    public async Task Publish(IEnumerable<NotificationHandlerExecutor> handlerExecutors, INotification notification, CancellationToken cancellationToken)
    {
        var exceptions = new List<Exception>();

        foreach (var handler in handlerExecutors)
        {
            try
            {
                // اجرای هر هندلر به ترتیب
                await handler.HandlerCallback(notification, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex) when (!(ex is OutOfMemoryException || ex is StackOverflowException))
            {
                // جمع‌آوری خطاها
                exceptions.Add(ex);
            }
        }

        if (exceptions.Any())
        {
            throw new AggregateException(exceptions);
        }
    }
}