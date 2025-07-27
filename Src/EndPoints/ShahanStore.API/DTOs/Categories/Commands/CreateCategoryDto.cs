using Common.Application.DTOs;

namespace ShahanStore.API.DTOs.Categories.Commands;

public sealed record CreateCategoryDto(
    string Title,
    string Slug,
    IFormFile? BannerImg,
    IFormFile? Icon,
    SeoDataDto SeoData);