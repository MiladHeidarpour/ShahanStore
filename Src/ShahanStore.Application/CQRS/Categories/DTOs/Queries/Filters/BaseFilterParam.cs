namespace ShahanStore.Application.CQRS.Categories.DTOs.Queries.Filters;

public record BaseFilterParam(
    int PageId = 1,
    int Take = 10);
