using Microsoft.EntityFrameworkCore;
using ShahanStore.Domain.Categories;
using ShahanStore.Infrastructure.Data;

namespace ShahanStore.Infrastructure.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Category?> GetByIdAsync(Guid categoryId)
    {
        return await Context.Categories
            .FirstOrDefaultAsync(c => c.Id == categoryId);
    }

    public async Task<List<Category>> GetAllChildrenAsync(Guid parentId)
    {
        return await Context.Categories
            .Where(c => c.ParentId == parentId)
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