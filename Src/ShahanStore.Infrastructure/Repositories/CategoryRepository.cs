using Common.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;
using ShahanStore.Domain.Categories;
using ShahanStore.Infrastructure.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ShahanStore.Infrastructure.Repositories;

public class CategoryRepository(AppDbContext context) : Repository<Category>(context), ICategoryRepository
{
    public async Task<Category?> FindByIdAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        return await Context.Categories.FindAsync(categoryId, cancellationToken);
    }
    public async Task<Category?> FindByIdWithDetailsAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        return await Context.Categories.Include(c=>c.Children)
            .Include(c=>c.CategoryAttributes).FirstOrDefaultAsync(f=>f.Id==categoryId, cancellationToken);
    }
    public async Task<Category?> GetByIdAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        return await Context.Categories.AsNoTracking().FirstOrDefaultAsync(f => f.Id == categoryId, cancellationToken);
    }
    public async Task<Category?> GetByIdWithDetailsAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        return await Context.Categories.AsNoTracking()
            .Include(c=>c.CategoryAttributes)
            .Include(c=>c.Children)
            .FirstOrDefaultAsync(f => f.Id == categoryId, cancellationToken);
    }
    public async Task<Category?> GetBySlugAsync(string slug, CancellationToken cancellationToken)
    {
        return await Context.Categories.AsNoTracking().FirstOrDefaultAsync(f => f.Slug == slug, cancellationToken);
    }
    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Context.Categories.AsNoTracking().ToListAsync(cancellationToken);
    }
    public async Task<bool> IsSlugDuplicateAsync(string slug, CancellationToken cancellationToken)
    {
        return await Context.Categories
            .AnyAsync(c => c.Slug == slug, cancellationToken);
    }
    public void Delete(Category category)
    {
        category.Delete();
    }
}