using Common.Application.DTOs;
using Common.Domain.ValueObjects;

namespace ShahanStore.API.DTOs.Categories.Commands;

public sealed record EditCategoryDto(
    Guid Id,
    string Title,
    string Slug,
    SeoDataDto SeoData);