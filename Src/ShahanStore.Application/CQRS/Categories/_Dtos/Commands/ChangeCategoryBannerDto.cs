namespace ShahanStore.Application.CQRS.Categories._Dtos.Commands;

public sealed record ChangeCategoryBannerDto(
    Guid CategoryId,
    string BannerImg);