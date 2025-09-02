using Microsoft.EntityFrameworkCore;
using ShahanStore.Domain.Brands;
using ShahanStore.Domain.Categories;
using ShahanStore.Domain.Products;

namespace ShahanStore.Application;

public interface IApplicationDbContext
{
    DbSet<Category> Categories { get; }
    DbSet<Brand> Brands { get; }
    DbSet<Product> Products { get; }
}