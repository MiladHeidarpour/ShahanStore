using Microsoft.EntityFrameworkCore;
using ShahanStore.Domain.Categories;
using ShahanStore.Infrastructure.Data;

namespace ShahanStore.Infrastructure.Repositories;

public class CategoryRepository(AppDbContext context) : Repository<Category>(context), ICategoryRepository
{
    public async Task<Category?> FindByIdAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        return await Context.Categories.FindAsync(categoryId, cancellationToken);
    }

    public async Task<Category?> GetByIdAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        return await Context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);
    }

    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Context.Categories.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<List<Category>> GetAllChildrenAsync(Guid parentId, CancellationToken cancellationToken)
    {
        return await Context.Categories
            .Where(c => c.ParentId == parentId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
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