namespace Common.Application.Dtos;

public record BaseDto(
    Guid Id,
    DateTimeOffset CreationDate);