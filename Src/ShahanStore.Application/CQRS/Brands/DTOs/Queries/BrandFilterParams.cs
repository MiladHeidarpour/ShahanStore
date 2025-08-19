using Common.Application.DTOs.Filters;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Application.CQRS.Brands.DTOs.Queries;

public record BrandFilterParams(
    string? Search,
    Status? Status,
    int PageId = 1,
    int Take = 10) : BaseFilterParam(PageId, Take);