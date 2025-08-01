using MediatR;

namespace Common.Infrastructure.MediatR;

public class AsyncPublisher : INotificationPublisher
{
    public Task Publish(IEnumerable<NotificationHandlerExecutor> handlerExecutors, INotification notification,
        CancellationToken cancellationToken)
    {
        var tasks = handlerExecutors.Select(handler => handler.HandlerCallback(notification, cancellationToken));
        return Task.WhenAll(tasks);
    }
}