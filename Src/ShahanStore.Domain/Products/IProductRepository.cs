namespace ShahanStore.Domain.Products;

public interface IProductRepository
{
    Task<Product?> FindByIdAsync(Guid productId, CancellationToken cancellationToken);
    Task<Product?> GetByIdAsync(Guid productId, CancellationToken cancellationToken);
    Task<Product?> GetBySlugAsync(string slug, CancellationToken cancellationToken);
    Task<Product?> GetByCodeAsync(string productCode, CancellationToken cancellationToken);
    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);
    void Add(Product product);
    void Update(Product product);
    Task<bool> IsSlugDuplicateAsync(string slug, CancellationToken cancellationToken);
    void Delete(Product product);
}
