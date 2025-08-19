using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Brands.DTOs.Queries;
using ShahanStore.Domain.Brands;

namespace ShahanStore.Application.CQRS.Brands.Queries.GetBySlug;

internal sealed class GetBrandBySlugQueryHandler(IBrandRepository brandRepository) : IQueryHandler<GetBrandBySlugQuery, BrandDto?>
{
    public async Task<BrandDto?> Handle(GetBrandBySlugQuery request, CancellationToken cancellationToken)
    {
        var brand = await brandRepository.GetBySlugAsync(request.Slug, cancellationToken);
        return brand.Map();
    }
}
