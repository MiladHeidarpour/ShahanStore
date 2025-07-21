using Microsoft.EntityFrameworkCore;
using ShahanStore.Domain.Categories;
using ShahanStore.Infrastructure.Data;

namespace ShahanStore.Infrastructure.Repositories;

public class CategoryRepository(AppDbContext context) : Repository<Category>(context), ICategoryRepository
{
    public async Task<Category?> GetByIdAsync(Guid categoryId)
    {
        return await Context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == categoryId);
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await Context.Categories.AsNoTracking().ToListAsync();
    }

    public async Task<List<Category>> GetAllChildrenAsync(Guid parentId)
    {
        return await Context.Categories
            .Where(c => c.ParentId == parentId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> IsSlugDuplicateAsync(string slug)
    {
        return await Context.Categories
            .AnyAsync(c => c.Slug == slug);
    }

    public void Delete(Category category)
    {
        category.Delete();
    }
}