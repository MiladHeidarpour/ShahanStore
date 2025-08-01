using Common.Application.DTOs;

namespace ShahanStore.Application.CQRS.Categories.DTOs.Queries;

public sealed record CategoryAttributeDto(
    Guid Id,
    DateTimeOffset CreationDate,
    string Name,
    List<string> PossibleValues
) : BaseDto(Id, CreationDate);