using Common.Application.DTOs;

namespace ShahanStore.API.DTOs.Categories.Commands;

public sealed record EditCategoryDto(
    Guid Id,
    string Title,
    string Slug,
    bool IsDeleted,
    SeoDataDto SeoData);