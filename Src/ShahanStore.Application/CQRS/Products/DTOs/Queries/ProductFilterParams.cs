using Common.Application.DTOs.Filters;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;

namespace ShahanStore.Application.CQRS.Products.DTOs.Queries;

public record ProductFilterParams(
    string? Search,
    Status? Status,
    int PageId = 1,
    int Take = 10) : BaseFilterParam(PageId, Take);
