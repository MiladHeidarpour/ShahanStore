using Common.Application.DTOs;

namespace ShahanStore.Application.CQRS.Brands.DTOs.Queries;

public record BrandFilterData(
    Guid Id,
    DateTimeOffset CreationDate,
    string Name,
    string Slug,
    string? Logo,
    bool IsAvailable) : BaseDto(Id, CreationDate);
