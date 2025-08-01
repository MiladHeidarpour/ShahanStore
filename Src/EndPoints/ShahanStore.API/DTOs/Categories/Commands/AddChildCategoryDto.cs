using Common.Application.DTOs;

namespace ShahanStore.API.DTOs.Categories.Commands;

public sealed record AddChildCategoryDto(
    string Title,
    string Slug,
    Guid ParentId,
    IFormFile? BannerImg,
    IFormFile? Icon,
    SeoDataDto SeoData);