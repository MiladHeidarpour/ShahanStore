using Common.Application.DTOs;
using Common.Domain.ValueObjects;
using Mapster;
using ShahanStore.API.DTOs.Brands.Commands;
using ShahanStore.Application.CQRS.Brands.Commands.Create;
using ShahanStore.Application.CQRS.Brands.Commands.Delete;
using ShahanStore.Application.CQRS.Brands.Commands.Edit;
using ShahanStore.Application.CQRS.Brands.DTOs.Queries;
using ShahanStore.Domain.Brands;

namespace ShahanStore.API.Configuration.Mapper;

public class BrandMappingConfig : IRegister
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

        config.NewConfig<Brand, BrandDto>();

        config.NewConfig<Brand, BrandFilterData>();

        config.NewConfig<CreateBrandDto, CreateBrandCommand>()
            .Map(dest => dest.BannerImg, src => src.BannerImg != null ? src.BannerImg.FileName : null)
            .Map(dest => dest.Logo, src => src.Logo != null ? src.Logo.FileName : null);

        config.NewConfig<EditBrandDto, EditBrandCommand>();
        config.NewConfig<DeleteBrandDto, DeleteBrandCommand>();
    }
}
