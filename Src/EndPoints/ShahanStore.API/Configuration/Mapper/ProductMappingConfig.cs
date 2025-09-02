using Common.Application.DTOs;
using Common.Domain.ValueObjects;
using Mapster;
using ShahanStore.Application.CQRS.Products.DTOs.Queries;
using ShahanStore.Domain.Products;

namespace ShahanStore.API.Configuration.Mapper;

public class ProductMappingConfig : IRegister
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

        config.NewConfig<Product, ProductDto>();

        config.NewConfig<Product, ProductFilterData>();

        config.NewConfig<CreateBrandDto, CreateBrandCommand>()
            .Map(dest => dest.BannerImg, src => src.BannerImg != null ? src.BannerImg.FileName : null)
            .Map(dest => dest.Logo, src => src.Logo != null ? src.Logo.FileName : null);

        config.NewConfig<EditBrandDto, EditBrandCommand>();
        config.NewConfig<DeleteBrandDto, DeleteBrandCommand>();
    }
}
