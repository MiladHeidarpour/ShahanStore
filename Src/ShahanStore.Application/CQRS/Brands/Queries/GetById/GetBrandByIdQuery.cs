using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Brands.DTOs.Queries;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;
using ShahanStore.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Application.CQRS.Brands.Queries.GetById;

public sealed record GetBrandByIdQuery(Guid BrandId):IQuery<BrandDto?>;
