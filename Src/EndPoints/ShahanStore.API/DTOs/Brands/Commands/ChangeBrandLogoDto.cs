namespace ShahanStore.API.DTOs.Brands.Commands;

public sealed record ChangeBrandLogoDto(
    Guid BrandId,
    IFormFile Logo);
