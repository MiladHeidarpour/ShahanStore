using Common.Application.DTOs;
using Common.Domain.ValueObjects;
using Mapster;
using ShahanStore.API.DTOs.Categories.Commands;
using ShahanStore.Application.CQRS.Categories.Commands.AddChild;
using ShahanStore.Application.CQRS.Categories.Commands.Create;
using ShahanStore.Application.CQRS.Categories.Commands.Delete;
using ShahanStore.Application.CQRS.Categories.Commands.Edit;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;
using ShahanStore.Domain.Categories;

namespace ShahanStore.API.Configuration.Mapper;

public class CategoryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<SeoDataDto, SeoData>()
            .ConstructUsing(src => new SeoData(
                src.MetaTitle,
                src.MetaDescription,
                src.IndexPage,
                src.Canonical,
                src.OgTitle,
                src.OgDescription,
                src.OgImage,
                src.Schema
            ));

        config.NewConfig<Category, CategoryDto>()
            .Map(dest => dest.Attributes, src => src.CategoryAttributes);

        //config.NewConfig<CreateCategoryDto, CreateCategoryCommand>();
        config.NewConfig<CreateCategoryDto, CreateCategoryCommand>()
            .Map(dest => dest.BannerImg, src => src.BannerImg != null ? src.BannerImg.FileName : null)
            .Map(dest => dest.Icon, src => src.Icon != null ? src.Icon.FileName : null);


        //config.NewConfig<AddChildCategoryDto, AddChildCategoryCommand>();
        config.NewConfig<AddChildCategoryDto, AddChildCategoryCommand>()
            .Map(dest => dest.BannerImg, src => src.BannerImg != null ? src.BannerImg.FileName : null)
            .Map(dest => dest.Icon, src => src.Icon != null ? src.Icon.FileName : null);

        config.NewConfig<EditCategoryDto, EditCategoryCommand>();
        config.NewConfig<DeleteCategoryDto, DeleteCategoryCommand>();
    }
}