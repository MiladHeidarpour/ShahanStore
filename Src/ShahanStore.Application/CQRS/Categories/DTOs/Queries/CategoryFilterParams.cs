namespace ShahanStore.Application.CQRS.Categories.DTOs.Queries;

public record CategoryFilterParams(
    Guid? CategoryId,
    string? Slug,
    string? Search,
    Status? Status,
    int PageId = 1,
    int Take = 10);

public enum Status
{
    Active,
    NotActive
}