using Common.Application.DTOs;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Application.CQRS.Brands.DTOs.Queries;

public sealed record BrandDto(
    Guid Id,
    DateTimeOffset CreationDate,
    string Name,
    string Slug,
    string? BannerImg,
    string? Logo,
    string? Description,
    bool IsAvailable,
    SeoDataDto SeoData) : BaseDto(Id, CreationDate);