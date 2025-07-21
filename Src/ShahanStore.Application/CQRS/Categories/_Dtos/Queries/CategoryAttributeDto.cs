namespace ShahanStore.Application.CQRS.Categories._Dtos.Queries;

public sealed record CategoryAttributeDto(
    Guid Id,
    string Name,
    List<string> PossibleValues
);