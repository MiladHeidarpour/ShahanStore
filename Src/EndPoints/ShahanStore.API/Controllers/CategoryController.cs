using Common.Application.Models.Results;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShahanStore.API.Common;
using ShahanStore.API.Common.FileUtil;
using ShahanStore.API.Common.FileUtil.Interfaces;
using ShahanStore.API.DTOs.Categories.Commands;
using ShahanStore.Application.CQRS.Categories.Commands.AddChild;
using ShahanStore.Application.CQRS.Categories.Commands.ChangeBanner;
using ShahanStore.Application.CQRS.Categories.Commands.ChangeIcon;
using ShahanStore.Application.CQRS.Categories.Commands.Create;
using ShahanStore.Application.CQRS.Categories.Commands.Delete;
using ShahanStore.Application.CQRS.Categories.Commands.Edit;
using ShahanStore.Application.CQRS.Categories.DTOs.Queries;
using ShahanStore.Application.CQRS.Categories.Queries.GetAll;
using ShahanStore.Application.CQRS.Categories.Queries.GetByFilter;
using ShahanStore.Application.CQRS.Categories.Queries.GetById;

namespace ShahanStore.API.Controllers;

public class CategoryController(IMediator mediator, IMapper mapper, ILocalFileService localFileService) : ApiController
{
    #region Commands

    [HttpPost]
    [ProducesDefaultResponseType(typeof(OperationResult))]
    public async Task<IActionResult> Create([FromForm] CreateCategoryDto request, CancellationToken cancellationToken)
    {
        string? bannerImgName = null;
        if (request.BannerImg is not null)
        {
            if (!request.BannerImg.IsValidImageFile())
                return HandleResult(OperationResult.Error("فایل بنر نامعتبر است"));

            bannerImgName = await localFileService.SaveFileAsync(request.BannerImg, AppDirectories.CategoryBanner);
        }

        string? iconImgName = null;
        if (request.Icon is not null)
        {
            if (!request.Icon.IsValidImageFile())
                return HandleResult(OperationResult.Error("فایل آیکون نامعتبر است"));

            iconImgName = await localFileService.SaveFileAsync(request.Icon, AppDirectories.CategoryIcon);
        }


        var command = mapper.Map<CreateCategoryCommand>(request);
        var finalCommand = command with { BannerImg = bannerImgName, Icon = iconImgName };
        //var command = new CreateCategoryCommand(
        //    request.Title,
        //    request.Slug,
        //    bannerImgName,
        //    iconImgName,
        //    new SeoData(
        //        request.SeoData.MetaTitle,
        //        request.SeoData.MetaDescription,
        //        request.SeoData.IndexPage,
        //        request.SeoData.Canonical,
        //        request.SeoData.OgTitle,
        //        request.SeoData.OgDescription,
        //        request.SeoData.OgImage,
        //        request.SeoData.Schema
        //    ));
        var result = await mediator.Send(finalCommand, cancellationToken);
        return HandleResult(result);
    }

    [HttpPut]
    [ProducesDefaultResponseType(typeof(OperationResult))]
    public async Task<IActionResult> Edit([FromForm] EditCategoryDto request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<EditCategoryCommand>(request);
        var result = await mediator.Send(command, cancellationToken);
        return HandleResult(result);
    }

    [HttpDelete]
    [ProducesDefaultResponseType(typeof(OperationResult))]
    public async Task<IActionResult> Delete(DeleteCategoryDto request, CancellationToken cancellationToken)
    {
        var command = mapper.Map<DeleteCategoryCommand>(request);
        var result = await mediator.Send(command, cancellationToken);
        return HandleResult(result);
    }

    [HttpPost]
    [Route("AddChild")]
    [ProducesDefaultResponseType(typeof(OperationResult))]
    public async Task<IActionResult> AddChild([FromForm] AddChildCategoryDto request,
        CancellationToken cancellationToken)
    {
        string? bannerImgName = null;
        if (request.BannerImg is not null)
        {
            if (!request.BannerImg.IsValidImageFile())
                return HandleResult(OperationResult.Error("فایل بنر نامعتبر است"));

            bannerImgName = await localFileService.SaveFileAsync(request.BannerImg, AppDirectories.CategoryBanner);
        }

        string? iconImgName = null;
        if (request.Icon is not null)
        {
            if (!request.Icon.IsValidImageFile())
                return HandleResult(OperationResult.Error("فایل آیکون نامعتبر است"));

            iconImgName = await localFileService.SaveFileAsync(request.Icon, AppDirectories.CategoryIcon);
        }

        var command = mapper.Map<AddChildCategoryCommand>(request);
        var finalCommand = command with { BannerImg = bannerImgName, Icon = iconImgName };

        var result = await mediator.Send(finalCommand, cancellationToken);
        return HandleResult(result);
    }

    [HttpPut]
    [Route("ChangeBanner")]
    [ProducesDefaultResponseType(typeof(OperationResult<string?>))]
    public async Task<IActionResult> ChangeBanner([FromForm] ChangeCategoryBannerDto request,
        CancellationToken cancellationToken)
    {
        if (request.BannerImg is null && !request.BannerImg.IsValidImageFile())
            return HandleResult(OperationResult.Error("فایل بنر نامعتبر است"));

        var bannerImgName = await localFileService.SaveFileAsync(request.BannerImg, AppDirectories.CategoryBanner);

        var command = new ChangeCategoryBannerCommand(
            request.CategoryId,
            bannerImgName);

        var result = await mediator.Send(command, cancellationToken);
        if (result.Data is not null) localFileService.DeleteFile(result.Data, AppDirectories.CategoryBanner);
        return HandleResult(result);
    }


    [HttpPut]
    [Route("ChangeIcon")]
    [ProducesDefaultResponseType(typeof(OperationResult<string?>))]
    public async Task<IActionResult> ChangeIcon([FromForm] ChangeCategoryIconDto request,
        CancellationToken cancellationToken)
    {
        if (!request.Icon.IsValidImageFile() && request.Icon is null)
            return HandleResult(OperationResult.Error("فایل بنر نامعتبر است"));

        var iconImgName = await localFileService.SaveFileAsync(request.Icon, AppDirectories.CategoryIcon);

        var command = new ChangeCategoryIconCommand(
            request.CategoryId,
            iconImgName);

        var result = await mediator.Send(command, cancellationToken);
        if (result.Data is not null) localFileService.DeleteFile(result.Data, AppDirectories.CategoryIcon);
        return HandleResult(result);
    }

    #endregion

    #region Queries

    [HttpGet]
    [Route("Filter")]
    [ProducesDefaultResponseType(typeof(OperationResult<CategoryDto>))]
    public async Task<IActionResult> GetByFilter([FromQuery] CategoryFilterParams filterParams,
        CancellationToken cancellationToken)
    {
        var query = new GetCategoriesByFilterQuery(filterParams);
        var result = await mediator.Send(query, cancellationToken);
        return HandleResult(OperationResult<CategoryFilterResult>.Success(result));
    }


    [HttpGet]
    [Route("{id:guid}")]
    [ProducesDefaultResponseType(typeof(OperationResult<CategoryDto>))]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCategoryByIdQuery(id);
        var result = await mediator.Send(query, cancellationToken);
        return HandleResult(OperationResult<CategoryDto>.Success(result));
    }


    [HttpGet]
    [Route("GetAll")]
    [ProducesDefaultResponseType(typeof(OperationResult<List<CategoryDto>>))]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllCategoriesQuery();
        var result = await mediator.Send(query, cancellationToken);
        return HandleResult(OperationResult<List<CategoryDto>>.Success(result));
    }

    #endregion
}