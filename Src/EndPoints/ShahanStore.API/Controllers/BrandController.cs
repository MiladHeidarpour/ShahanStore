using Common.Application.Models.Results;
using MapsterMapper;
using MediatR;

using Microsoft.AspNetCore.Mvc;
using ShahanStore.API.Common;
using ShahanStore.API.Common.FileUtil;
using ShahanStore.API.Common.FileUtil.Interfaces;
using ShahanStore.API.DTOs.Brands.Commands;
using ShahanStore.Application.CQRS.Brands.Commands.ChangeBanner;
using ShahanStore.Application.CQRS.Brands.Commands.ChangeLogo;
using ShahanStore.Application.CQRS.Brands.Commands.Create;
using ShahanStore.Application.CQRS.Brands.Commands.Delete;
using ShahanStore.Application.CQRS.Brands.Commands.Edit;
using ShahanStore.Application.CQRS.Brands.DTOs.Queries;
using ShahanStore.Application.CQRS.Brands.Queries.GetAll;
using ShahanStore.Application.CQRS.Brands.Queries.GetByFilter;
using ShahanStore.Application.CQRS.Brands.Queries.GetById;
using ShahanStore.Application.CQRS.Brands.Queries.GetBySlug;

namespace ShahanStore.API.Controllers;

public class BrandController  (IMediator mediator, IMapper mapper, ILocalFileService localFileService) : ApiController
{
    #region Commands

    [HttpPost]
    [ProducesDefaultResponseType(typeof(OperationResult))]
    public async Task<IActionResult> Create([FromForm] CreateBrandDto request, CancellationToken cancellationToken)
    {
        string? bannerImgName = null;
        if (request.BannerImg is not null)
        {
            if (!request.BannerImg.IsValidImageFile())
                return HandleResult(OperationResult.Error("فایل بنر نامعتبر است"));

            bannerImgName = await localFileService.SaveFileAsync(request.BannerImg, AppDirectories.BrandBanner);
        }

        string? logoImgName = null;
        if (request.Logo is not null)
        {
            if (!request.Logo.IsValidImageFile())
                return HandleResult(OperationResult.Error("فایل آیکون نامعتبر است"));

            logoImgName = await localFileService.SaveFileAsync(request.Logo, AppDirectories.BrandLogo);
        }

        var command = mapper.Map<CreateBrandCommand>(request);
        var finalCommand = command with { BannerImg = bannerImgName, Logo = logoImgName };
        var result = await mediator.Send(finalCommand, cancellationToken);
        return HandleResult(result);
    }



    [HttpPut]
    [ProducesDefaultResponseType(typeof(OperationResult))]
    public async Task<IActionResult> Edit([FromForm] EditBrandDto request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<EditBrandCommand>(request);
        var result = await mediator.Send(command, cancellationToken);
        return HandleResult(result);
    }



    [HttpDelete("{brandId}")]
    [ProducesDefaultResponseType(typeof(OperationResult))]
    public async Task<IActionResult> Delete([FromRoute] Guid brandId, CancellationToken cancellationToken)
    {
        var command = mapper.Map<DeleteBrandCommand>(new DeleteBrandDto(brandId));
        var result = await mediator.Send(command, cancellationToken);
        return HandleResult(result);
    }



    [HttpPut]
    [Route("ChangeBanner")]
    [ProducesDefaultResponseType(typeof(OperationResult<string?>))]
    public async Task<IActionResult> ChangeBanner([FromForm] ChangeBrandBannerDto request, CancellationToken cancellationToken)
    {
        if (!request.BannerImg.IsValidImageFile() && request.BannerImg is null)
            return HandleResult(OperationResult.Error("فایل بنر نامعتبر است"));

        var bannerImgName = await localFileService.SaveFileAsync(request.BannerImg, AppDirectories.BrandBanner);

        var command = new ChangeBrandBannerCommand(
            request.BrandId,
            bannerImgName);

        var result = await mediator.Send(command, cancellationToken);
        if (result.Data is not null) localFileService.DeleteFile(result.Data, AppDirectories.BrandBanner);
        return HandleResult(result);
    }



    [HttpPut]
    [Route("ChangeLogo")]
    [ProducesDefaultResponseType(typeof(OperationResult<string?>))]
    public async Task<IActionResult> ChangeIcon([FromForm] ChangeBrandLogoDto request, CancellationToken cancellationToken)
    {
        if (!request.Logo.IsValidImageFile() && request.Logo is null)
            return HandleResult(OperationResult.Error("فایل لوگو نامعتبر است"));

        var iconImgName = await localFileService.SaveFileAsync(request.Logo, AppDirectories.BrandLogo);

        var command = new ChangeBrandLogoCommand(
            request.BrandId,
            iconImgName);

        var result = await mediator.Send(command, cancellationToken);
        if (result.Data is not null) localFileService.DeleteFile(result.Data, AppDirectories.BrandLogo);
        return HandleResult(result);
    }

    #endregion




    #region Queries

    [HttpGet]
    [Route("Filter")]
    [ProducesDefaultResponseType(typeof(OperationResult<BrandDto>))]
    public async Task<IActionResult> GetByFilter([FromQuery] BrandFilterParams filterParams, CancellationToken cancellationToken)
    {
        var query = new GetBrandsByFilterQuery(filterParams);
        var result = await mediator.Send(query, cancellationToken);
        return HandleResult(OperationResult<BrandFilterResult>.Success(result));
    }



    [HttpGet]
    [Route("GetAll")]
    [ProducesDefaultResponseType(typeof(OperationResult<List<BrandDto>>))]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllBrandsQuery();
        var result = await mediator.Send(query, cancellationToken);
        return HandleResult(OperationResult<List<BrandDto>>.Success(result));
    }



    [HttpGet]
    [Route("{id:guid}")]
    [ProducesDefaultResponseType(typeof(OperationResult<BrandDto>))]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetBrandByIdQuery(id);
        var result = await mediator.Send(query, cancellationToken);
        return HandleResult(OperationResult<BrandDto>.Success(result));
    }



    [HttpGet]
    [Route("{slug}")]
    [ProducesDefaultResponseType(typeof(OperationResult<BrandDto>))]
    public async Task<IActionResult> GetBySlug(string slug, CancellationToken cancellationToken)
    {
        var query = new GetBrandBySlugQuery(slug);
        var result = await mediator.Send(query, cancellationToken);
        return HandleResult(OperationResult<BrandDto>.Success(result));
    }
    #endregion
}
