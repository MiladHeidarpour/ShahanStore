using Common.Domain.ValueObjects;

namespace ShahanStore.Application.CQRS.Categories._Dtos.Commands;

public sealed record AddChildCategoryDto(
    string Title,
    string Slug,
    Guid ParentId,
    string? BannerImg,
    string? Icon,
    SeoData SeoData);