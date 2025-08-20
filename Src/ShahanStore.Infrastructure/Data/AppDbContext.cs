using Common.Domain.Bases;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShahanStore.Application;
using ShahanStore.Domain.Brands;
using ShahanStore.Domain.Categories;
using ShahanStore.Infrastructure.BackgroundJobs.Models;

namespace ShahanStore.Infrastructure.Data;

public class AppDbContext : DbContext, IApplicationDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<OutboxMessage> OutboxMessages { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // ۱. پیدا کردن تمام رویدادهای دامنه
        var domainEvents = ChangeTracker.Entries<AggregateRoot>()
            .Select(e => e.Entity)
            .SelectMany(aggregateRoot =>
            {
                var events = aggregateRoot.DomainEvents.ToList();
                aggregateRoot.ClearDomainEvents();
                return events;
            })
            .ToList();

        // ۲. تبدیل رویدادها به پیام‌های Outbox
        var outboxMessages = domainEvents.Select(domainEvent => new OutboxMessage(
            domainEvent.GetType().Name,
            JsonConvert.SerializeObject(domainEvent, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All // برای سریالایز کردن نوع دقیق رویداد
            }))).ToList();

        // ۳. اضافه کردن پیام‌ها به DbContext
        await OutboxMessages.AddRangeAsync(outboxMessages, cancellationToken);

        // ۴. ذخیره همه چیز در یک تراکنش (هم داده‌های اصلی و هم پیام‌های Outbox)
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}