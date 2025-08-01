namespace ShahanStore.Application.CQRS.Categories.DTOs.Queries.Filters;

public class BaseFilterParam
{
    public int PageId { get; set; } = 1;
    public int Take { get; set; } = 10;
}