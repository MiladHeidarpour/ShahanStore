using Common.Application.Abstractions.Messaging.Queries;
using Common.Application.DTOs;
using ShahanStore.Application.CQRS.Brands.DTOs.Queries;
using ShahanStore.Domain.Brands;

namespace ShahanStore.Application.CQRS.Brands.Queries.GetAll;

internal sealed class GetAllBrandsQueryHandler(IBrandRepository brandRepository) : IQueryHandler<GetAllBrandsQuery, List<BrandDto>>
{
    public async Task<List<BrandDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var query = await brandRepository.GetAllAsync(cancellationToken);

        return query
            .Select(brand => new BrandDto(
                brand.Id,
                brand.CreationDate,
                brand.Name,
                brand.Slug,
                brand.BannerImg,
                brand.Logo,
                brand.Description,
                brand.IsAvailable,
                new SeoDataDto(
                    brand.SeoData.MetaTitle,
                    brand.SeoData.MetaDescription,
                    brand.SeoData.IndexPage,
                    brand.SeoData.Canonical,
                    brand.SeoData.OgTitle,
                    brand.SeoData.OgDescription,
                    brand.SeoData.OgImage,
                    brand.SeoData.Schema
                )
            )).ToList();
    }
}
