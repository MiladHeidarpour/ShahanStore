namespace Common.Application.DTOs;

public record BaseDto(
    Guid Id,
    DateTimeOffset CreationDate);