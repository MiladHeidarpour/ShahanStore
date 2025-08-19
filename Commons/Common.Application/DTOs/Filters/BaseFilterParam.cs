namespace Common.Application.DTOs.Filters;

public record BaseFilterParam(
    int PageId = 1,
    int Take = 10);
