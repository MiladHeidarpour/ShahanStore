using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShahanStore.Domain.Brands;
using ShahanStore.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Infrastructure.Configuration.Persistence.Brands;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands", "dbo");
        builder.HasKey(b => b.Id);
        builder.HasIndex(b => b.Slug).IsUnique();

        builder.Property(b => b.Name).IsRequired().HasMaxLength(150);
        builder.Property(b => b.Slug).IsRequired().HasMaxLength(150).IsUnicode(false);


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
