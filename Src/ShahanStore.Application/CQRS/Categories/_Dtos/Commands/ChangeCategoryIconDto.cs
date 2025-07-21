namespace ShahanStore.Application.CQRS.Categories._Dtos.Commands;

public sealed record ChangeCategoryIconDto(
    Guid CategoryId,
    string Icon);