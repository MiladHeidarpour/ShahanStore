using Common.Application.Abstractions.Messaging.Queries;
using Common.Application.DTOs;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;
using ShahanStore.Domain.Categories;
using Microsoft.EntityFrameworkCore;

namespace ShahanStore.Application.CQRS.Categories.Queries.GetAll;

internal sealed class GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
    : IQueryHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var query = await _categoryRepository.GetAllAsync(cancellationToken);

        return query
            .Select(category => new CategoryDto(
                category.Id,
                category.CreationDate, category.Title,
                category.Slug,
                category.ParentId,
                category.BannerImg,
                category.Icon,
                category.IsDeleted,
                new SeoDataDto(
                    category.SeoData.MetaTitle,
                    category.SeoData.MetaDescription,
                    category.SeoData.IndexPage,
                    category.SeoData.Canonical,
                    category.SeoData.OgTitle,
                    category.SeoData.OgDescription,
                    category.SeoData.OgImage,
                    category.SeoData.Schema
                ),
                category.Children.Select(child => new ChildCategoryDto(
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
                        child.SeoData.Schema
                    ),
                    child.CategoryAttributes
                        .Select(attr => new CategoryAttributeDto(
                            attr.Id,
                            attr.CreationDate,
                            attr.Name,
                            attr.PossibleValues
                        )).ToList()
                )).ToList(),
                category.CategoryAttributes
                    .Select(attr => new CategoryAttributeDto(
                        attr.Id,
                        attr.CreationDate,
                        attr.Name,
                       attr.PossibleValues
                    )).ToList()
            )).ToList();


        /*var categories = await _categoryRepository.GetAllAsync(cancellationToken);
        return categories.Map();*/
    }
}