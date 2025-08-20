using Microsoft.EntityFrameworkCore;
using ShahanStore.Domain.Brands;
using ShahanStore.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Infrastructure.Repositories;

public class BrandRepository(AppDbContext context) : Repository<Brand>(context), IBrandRepository
{
    public async Task<Brand?> FindByIdAsync(Guid brandId, CancellationToken cancellationToken)
    {
        return await Context.Brands.FindAsync(brandId, cancellationToken);
    }
    public async Task<Brand?> GetByIdAsync(Guid brandId, CancellationToken cancellationToken)
    {
        return await Context.Brands.AsNoTracking().FirstOrDefaultAsync(f => f.Id == brandId, cancellationToken);
    }
    public async Task<Brand?> GetBySlugAsync(string slug, CancellationToken cancellationToken)
    {
        return await Context.Brands.AsNoTracking().FirstOrDefaultAsync(f => f.Slug == slug, cancellationToken);
    }
    public async Task<List<Brand>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Context.Brands.AsNoTracking().ToListAsync(cancellationToken);
    }
    public async Task<bool> IsSlugDuplicateAsync(string slug, CancellationToken cancellationToken)
    {
        return await Context.Brands
            .AnyAsync(c => c.Slug == slug, cancellationToken);
    }
    public void Delete(Brand brand)
    {
        brand.Delete();
    }
}
