using MediatR;

namespace Common.Infrastructure.MediatR;

public class ParallelWhenAnyPublisher : INotificationPublisher
{
    public Task Publish(IEnumerable<NotificationHandlerExecutor> handlerExecutors, INotification notification, CancellationToken cancellationToken)
    {
        var tasks = handlerExecutors.Select(handler => Task.Run(() => handler.HandlerCallback(notification, cancellationToken)));
        return Task.WhenAny(tasks);
    }
}