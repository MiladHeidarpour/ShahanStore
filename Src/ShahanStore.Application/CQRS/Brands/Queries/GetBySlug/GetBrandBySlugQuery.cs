using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Brands.DTOs.Queries;
using ShahanStore.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Application.CQRS.Brands.Queries.GetBySlug;

public sealed record GetBrandBySlugQuery(string Slug):IQuery<BrandDto?>;
