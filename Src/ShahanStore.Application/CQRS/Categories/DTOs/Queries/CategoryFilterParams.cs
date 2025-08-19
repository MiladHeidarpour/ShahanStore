using Common.Application.DTOs.Filters;

namespace ShahanStore.Application.CQRS.Categories.DTOs.Queries;

public record CategoryFilterParams(
    string? Search,
    Status? Status,
    int PageId = 1,
    int Take = 10):BaseFilterParam(PageId,Take);
