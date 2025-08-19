using Common.Application.DTOs.Filters;
using ShahanStore.Application.CQRS.Brands.DTOs.Queries;

namespace ShahanStore.Application.CQRS.Brands.Queries.GetByFilter;
public sealed class GetBrandsByFilterQuery : QueryFilter<BrandFilterResult, BrandFilterParams>
{
    public GetBrandsByFilterQuery(BrandFilterParams filterParams) : base(filterParams)
    {
    }
}