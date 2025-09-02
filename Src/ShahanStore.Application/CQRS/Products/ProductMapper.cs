using Common.Application.DTOs;
using ShahanStore.Application.CQRS.Products.DTOs.Queries;
using ShahanStore.Domain.Products;

namespace ShahanStore.Application.CQRS.Products;

public static class ProductMapper
{
    public static ProductDto? Map(this Product? product)
    {
        if (product == null) return null;

        var seoDataDto = new SeoDataDto(
            product.SeoData.MetaTitle,
            product.SeoData.MetaDescription,
            product.SeoData.IndexPage,
            product.SeoData.Canonical,
            product.SeoData.OgTitle,
            product.SeoData.OgDescription,
            product.SeoData.OgImage,
            product.SeoData.Schema);


        return new ProductDto(
            product.Id,
            product.CreationDate,
            product.FaName,
            product.EnName,
            product.Slug,
            product.ProductCode,
            product.ShortDescription,
            product.ExpertReview,
            product.MainImg,
            product.CategoryId,
            product.BrandId,
            product.IsAvailable,
            seoDataDto);
    }

    public static List<ProductDto> Map(this List<Product> products)
    {
        return products.Select(product => product.Map()!).ToList();
    }
}
