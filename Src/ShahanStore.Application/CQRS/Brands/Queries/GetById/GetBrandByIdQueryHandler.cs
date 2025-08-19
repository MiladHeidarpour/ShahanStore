using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Brands.DTOs.Queries;
using ShahanStore.Domain.Brands;

namespace ShahanStore.Application.CQRS.Brands.Queries.GetById;

internal sealed class GetBrandByIdQueryHandler(IBrandRepository brandRepository) : IQueryHandler<GetBrandByIdQuery, BrandDto?>
{
    public async Task<BrandDto?> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
    {
        var brand = await brandRepository.GetByIdAsync(request.BrandId, cancellationToken);
        return brand.Map();
    }
}