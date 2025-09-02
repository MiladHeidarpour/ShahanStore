using Common.Application.DTOs;

namespace ShahanStore.Application.CQRS.Products.DTOs.Queries;

public record ProductFilterData(
    Guid Id,
    DateTimeOffset CreationDate,
    string FaName,
    string EnName,
    string Slug,
    string ProductCode,
    string MainImg,
    Guid CategoryId,
    Guid BrandId,
    bool IsAvailable) : BaseDto(Id, CreationDate);
