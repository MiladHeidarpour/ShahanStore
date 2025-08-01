using Microsoft.EntityFrameworkCore;
using ShahanStore.Domain.Categories;

namespace ShahanStore.Application;

public interface IApplicationDbContext
{
    DbSet<Category> Categories { get; }
}