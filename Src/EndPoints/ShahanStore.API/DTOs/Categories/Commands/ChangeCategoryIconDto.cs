namespace ShahanStore.API.DTOs.Categories.Commands;

public sealed record ChangeCategoryIconDto(
    Guid CategoryId,
    IFormFile Icon);