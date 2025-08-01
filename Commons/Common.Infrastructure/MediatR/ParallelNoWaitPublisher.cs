﻿using MediatR;

namespace Common.Infrastructure.MediatR;

public class ParallelNoWaitPublisher : INotificationPublisher
{
    public Task Publish(IEnumerable<NotificationHandlerExecutor> handlerExecutors, INotification notification,
        CancellationToken cancellationToken)
    {
        foreach (var handler in handlerExecutors)
            _ = Task.Run(() => handler.HandlerCallback(notification, cancellationToken));
        return Task.CompletedTask;
    }
}