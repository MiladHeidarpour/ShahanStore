using Common.Domain.Repositories;

namespace ShahanStore.Domain.Categories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category?> FindByIdAsync(Guid categoryId, CancellationToken cancellationToken);
    Task<Category?> FindByIdWithDetailsAsync(Guid categoryId, CancellationToken cancellationToken);
    Task<Category?> GetByIdAsync(Guid categoryId, CancellationToken cancellationToken);
    Task<Category?> GetByIdWithDetailsAsync(Guid categoryId, CancellationToken cancellationToken);
    Task<Category?> GetBySlugAsync(string slug, CancellationToken cancellationToken);
    Task<List<Category>> GetAllAsync(CancellationToken cancellationToken);
    void Add(Category category);
    void Update(Category category);
    Task<bool> IsSlugDuplicateAsync(string slug, CancellationToken cancellationToken);
    void Delete(Category category);
}