namespace ShahanStore.API.DTOs.Categories.Commands;

public sealed record ChangeCategoryBannerDto(
    Guid CategoryId,
    IFormFile BannerImg);