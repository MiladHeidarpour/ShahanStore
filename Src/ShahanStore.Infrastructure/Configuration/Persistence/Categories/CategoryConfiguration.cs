using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShahanStore.Domain.Categories;

namespace ShahanStore.Infrastructure.Configuration.Persistence.Categories;

public class CategoryConfiguration:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories", "dbo");
        builder.HasKey(b => b.Id);
        builder.HasIndex(b => b.Slug).IsUnique();

        builder.Property(b => b.Title).IsRequired().HasMaxLength(150);
        builder.Property(b => b.Slug).IsRequired().HasMaxLength(150).IsUnicode(false);

        builder.HasOne<Category>()
            .WithMany()
            .HasForeignKey(c => c.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(b=>b.CategoryAttributes)
            .WithOne()
            .HasForeignKey(f => f.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.OwnsOne(b => b.SeoData, config =>
        {
            config.Property(b => b.MetaTitle).HasMaxLength(500).HasColumnName("MetaTitle");
            config.Property(b => b.MetaDescription).HasMaxLength(500).HasColumnName("MetaDescription");

            config.Property(b => b.IndexPage).HasColumnName("IndexPage");
            config.Property(b => b.Canonical).HasMaxLength(500).HasColumnName("Canonical");

            config.Property(b => b.OgTitle).HasMaxLength(500).HasColumnName("OgTitle");
            config.Property(b => b.OgDescription).HasMaxLength(500).HasColumnName("OgDescription");
            config.Property(b => b.OgImage).HasMaxLength(500).HasColumnName("OgImage");
            config.Property(b => b.Schema).HasColumnName("Schema");
        });
    }
}