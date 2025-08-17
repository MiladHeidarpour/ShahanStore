using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;
using ShahanStore.Application.CQRS.Categories.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Application.CQRS.Categories.Queries.GetBySlug;

public sealed record GetCategoryBySlugQuery(string Slug):IQuery<CategoryDto?>;
