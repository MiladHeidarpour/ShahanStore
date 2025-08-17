using Common.Application.DTOs;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;
using ShahanStore.Domain.Categories;
using System.Linq;

namespace ShahanStore.Application.CQRS.Categories;

internal static class CategoryMapper
{
    public static CategoryDto? Map(this Category? category)
    {
        if (category == null) return null;

        var seoDataDto = new SeoDataDto(
            category.SeoData.MetaTitle,
            category.SeoData.MetaDescription,
            category.SeoData.IndexPage,
            category.SeoData.Canonical,
            category.SeoData.OgTitle,
            category.SeoData.OgDescription,
            category.SeoData.OgImage,
            category.SeoData.Schema);


        var attributeDtos = category.CategoryAttributes
            .Select(attr => new CategoryAttributeDto(attr.Id, attr.CreationDate, attr.Name, attr.PossibleValues))
            .ToList();


        var childrenDto = category.Children
            .Select(child => new ChildCategoryDto(
                child.Id,
            child.CreationDate,
            child.Title,
            child.Slug,
            child.ParentId,
            child.BannerImg,
            child.Icon,
            child.IsDeleted,
            new SeoDataDto(
            child.SeoData.MetaTitle,
            child.SeoData.MetaDescription,
            child.SeoData.IndexPage,
            child.SeoData.Canonical,
            child.SeoData.OgTitle,
            child.SeoData.OgDescription,
            child.SeoData.OgImage,
            child.SeoData.Schema),
            child.CategoryAttributes
            .Select(attr => new CategoryAttributeDto(attr.Id, attr.CreationDate, attr.Name, attr.PossibleValues))
            .ToList())).ToList();


        return new CategoryDto(
            category.Id,
            category.CreationDate,
            category.Title,
            category.Slug,
            category.ParentId,
            category.BannerImg,
            category.Icon,
            category.IsDeleted,
            seoDataDto,
            childrenDto,
            attributeDtos);
    }

    public static List<CategoryDto> Map(this List<Category> categories)
    {
        return categories.Select(category => category.Map()!).ToList();
    }
}