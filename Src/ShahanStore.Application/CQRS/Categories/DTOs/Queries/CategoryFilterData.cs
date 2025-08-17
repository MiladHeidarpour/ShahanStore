using Common.Application.DTOs;

namespace ShahanStore.Application.CQRS.Categories.DTOs.Queries;

public record CategoryFilterData(
    Guid Id,
    DateTimeOffset CreationDate,
    string Title,
    string Slug,
    string? Icon,
    bool IsDeleted) : BaseDto(Id, CreationDate);