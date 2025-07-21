using Common.Application.Dtos;

namespace ShahanStore.Application.CQRS.Categories._Dtos.Queries;

public sealed record CategoryDto(
    Guid Id,
    DateTimeOffset CreationDate,
    string Title,
    string Slug,
    Guid? ParentId,
    string? BannerImg,
    string? Icon,
    bool IsDeleted,
    SeoDataDto SeoData,
    List<CategoryAttributeDto> Attributes) :BaseDto(Id, CreationDate);