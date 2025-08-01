using Common.Application.DTOs;

namespace ShahanStore.API.DTOs.Categories.Commands;

public sealed record EditCategoryDto(
    Guid Id,
    string Title,
    string Slug,
    SeoDataDto SeoData);