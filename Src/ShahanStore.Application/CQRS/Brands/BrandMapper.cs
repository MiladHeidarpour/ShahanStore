using Common.Application.DTOs;
using ShahanStore.Application.CQRS.Brands.DTOs.Queries;
using ShahanStore.Application.CQRS.Categories;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;
using ShahanStore.Domain.Brands;
using ShahanStore.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Application.CQRS.Brands;

public static class BrandMapper
{
    public static BrandDto? Map(this Brand? brand)
    {
        if (brand == null) return null;

        var seoDataDto = new SeoDataDto(
            brand.SeoData.MetaTitle,
            brand.SeoData.MetaDescription,
            brand.SeoData.IndexPage,
            brand.SeoData.Canonical,
            brand.SeoData.OgTitle,
            brand.SeoData.OgDescription,
            brand.SeoData.OgImage,
            brand.SeoData.Schema);


        return new BrandDto(
            brand.Id,
            brand.CreationDate,
            brand.Name,
            brand.Slug,
            brand.BannerImg,
            brand.Logo,
            brand.Description,
            brand.IsAvailable,
            seoDataDto);
    }

    public static List<BrandDto> Map(this List<Brand> brands)
    {
        return brands.Select(brand => brand.Map()!).ToList();
    }
}
