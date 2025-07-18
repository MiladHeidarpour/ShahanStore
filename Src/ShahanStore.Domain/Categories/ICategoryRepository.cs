using Common.Domain.Repositories;

namespace ShahanStore.Domain.Categories;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<Category?> GetByIdAsync(Guid categoryId);
    Task<List<Category>> GetAllChildrenAsync(Guid parentId);
    void Add(Category category);
    Task<bool> IsSlugDuplicateAsync(string slug);
    void Delete(Category category);
}