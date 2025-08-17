using ShahanStore.Application.CQRS.Categories.DTOs.Queries.Filters;

namespace ShahanStore.Application.CQRS.Categories.DTOs.Queries;

public record CategoryFilterParams(
    string? Search,
    Status? Status,
    int PageId = 1,
    int Take = 10):BaseFilterParam(PageId,Take);

public enum Status
{
    Active,
    NotActive
}