using Common.Application.DTOs.Filters;
using ShahanStore.Application.CQRS.Products.DTOs.Queries;

namespace ShahanStore.Application.CQRS.Products.Queries.GetByFilter;
public sealed class GetProductByFilterQuery : QueryFilter<ProductFilterResult, ProductFilterParams>
{
    public GetProductByFilterQuery(ProductFilterParams filterParams) : base(filterParams)
    {
    }
}
