namespace ShahanStore.API.DTOs.Brands.Commands;

public sealed record ChangeBrandBannerDto(
    Guid BrandId,
    IFormFile BannerImg);
