using ShahanStore.Application.CQRS.Categories.DTOs.Queries;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries.Filters;

namespace ShahanStore.Application.CQRS.Categories.Queries.GetByFilter;

public sealed class GetCategoriesByFilterQuery : QueryFilter<CategoryFilterResult, CategoryFilterParams>
{
    public GetCategoriesByFilterQuery(CategoryFilterParams filterParams) : base(filterParams)
    {
    }
}