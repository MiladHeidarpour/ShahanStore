using Common.Application.Abstractions.Messaging.Commands;
using Common.Application.DTOs;
using Common.Domain.ValueObjects;

namespace ShahanStore.API.DTOs.Brands.Commands;

public sealed record CreateBrandDto(
    string Name,
    string Slug,
    IFormFile? BannerImg,
    IFormFile? Logo,
    string? Description,
    SeoDataDto SeoData);
