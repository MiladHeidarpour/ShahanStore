using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShahanStore.Infrastructure.Data;

namespace ShahanStore.Infrastructure.BackgroundJobs;

public class ProcessOutboxMessagesJob : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<ProcessOutboxMessagesJob> _logger;

    public ProcessOutboxMessagesJob(IServiceProvider serviceProvider, ILogger<ProcessOutboxMessagesJob> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await ProcessMessages(stoppingToken);
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken); // هر ۱۰ ثانیه یک بار
        }
    }

    private async Task ProcessMessages(CancellationToken stoppingToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var publisher = scope.ServiceProvider.GetRequiredService<IPublisher>(); // IMediator یا ICustomPublisher

        var messages = await dbContext.OutboxMessages
            .Where(m => m.ProcessedOnUtc == null)
            .Take(20) // برای جلوگیری از بار زیاد، هر بار ۲۰ پیام را پردازش می‌کنیم
            .ToListAsync(stoppingToken);

        foreach (var message in messages)
        {
            try
            {
                var domainEvent = JsonConvert.DeserializeObject(message.Content, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                }) as INotification;

                if (domainEvent is null) continue;

                await publisher.Publish(domainEvent, stoppingToken);

                message.MarkAsProcessed();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to process Outbox message {MessageId}", message.Id);
                message.MarkAsFailed(ex.ToString());
            }
        }

        await dbContext.SaveChangesAsync(stoppingToken);
    }
}