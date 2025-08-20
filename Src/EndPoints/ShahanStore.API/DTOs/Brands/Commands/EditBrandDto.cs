using Common.Application.DTOs;
using Common.Domain.ValueObjects;

namespace ShahanStore.API.DTOs.Brands.Commands;

public sealed record EditBrandDto(
    Guid Id,
    string Name,
    string Slug,
    string? Description,
    bool IsAvailable,
    SeoDataDto SeoData);
