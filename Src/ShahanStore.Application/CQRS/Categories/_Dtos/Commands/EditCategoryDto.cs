using Common.Domain.ValueObjects;

namespace ShahanStore.Application.CQRS.Categories._Dtos.Commands;

public sealed record EditCategoryDto(
    Guid Id,
    string Title,
    string Slug,
    SeoData SeoData);