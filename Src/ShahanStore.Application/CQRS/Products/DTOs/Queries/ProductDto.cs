using Common.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Application.CQRS.Products.DTOs.Queries;
public sealed record ProductDto(
    Guid Id,
    DateTimeOffset CreationDate,
    string FaName,
    string EnName,
    string Slug,
    string ProductCode,
    string? ShortDescription,
    string? ExpertReview,
    string MainImg,
    Guid CategoryId,
    Guid BrandId,
    bool IsAvailable,
    SeoDataDto SeoData);
