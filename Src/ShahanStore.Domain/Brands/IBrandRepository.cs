using Common.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Domain.Brands;

public interface IBrandRepository:IRepository<Brand>
{
    Task<Brand?> FindByIdAsync(Guid brandId, CancellationToken cancellationToken);
    Task<Brand?> GetByIdAsync(Guid brandId, CancellationToken cancellationToken);
    Task<Brand?> GetBySlugAsync(string slug, CancellationToken cancellationToken);
    Task<List<Brand>> GetAllAsync(CancellationToken cancellationToken);
    void Add(Brand brand);
    void Update(Brand brand);
    Task<bool> IsSlugDuplicateAsync(string slug, CancellationToken cancellationToken);
    void Delete(Brand brand);
}
