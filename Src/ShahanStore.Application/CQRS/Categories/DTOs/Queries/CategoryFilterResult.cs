using ShahanStore.Application.CQRS.Categories.DTOs.Queries.Filters;

namespace ShahanStore.Application.CQRS.Categories.DTOs.Queries;

public class CategoryFilterResult : BaseFilterResult
{
    public List<CategoryDto> Categories { get; set; }
}