using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShahanStore.Infrastructure.BackgroundJobs.Models;

namespace ShahanStore.Infrastructure.Configuration.Persistence.OutboxMessages;

public class OutboxMessageConfiguration:IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder.ToTable("OutboxMessages", "dbo");
        builder.HasKey(om => om.Id);

        builder.Property(om => om.Type).IsRequired();
        builder.Property(om => om.Content).IsRequired();

        builder.HasIndex(om => om.ProcessedOnUtc);
    }
}