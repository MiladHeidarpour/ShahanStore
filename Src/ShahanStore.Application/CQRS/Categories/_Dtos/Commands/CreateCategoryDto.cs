using Common.Application.Dtos;

namespace ShahanStore.Application.CQRS.Categories._Dtos.Commands;

public sealed record CreateCategoryDto(
    string Title,
    string Slug,
    string? BannerImg,
    string? Icon,
    SeoDataDto SeoData);