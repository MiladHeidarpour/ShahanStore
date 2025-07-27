using Common.Application.Models.Results;
using Microsoft.AspNetCore.Mvc;

namespace ShahanStore.API.Common;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiController : ControllerBase
{
    protected IActionResult HandleResult(OperationResult result)
    {
        return result.Status switch
        {
            OperationResultStatus.Success => Ok(ApiResult.Success(result.Message)),
            OperationResultStatus.NotFound => NotFound(ApiResult.Error(result.Message)),
            OperationResultStatus.Error => BadRequest(ApiResult.Error(result.Message)),
            _ => BadRequest(ApiResult.Error(result.Message))
        };
    }

    protected IActionResult HandleResult<TData>(OperationResult<TData> result)
    {
        return result.Status switch
        {
            OperationResultStatus.Success => Ok(ApiResult<TData>.Success(result.Data, result.Message)),
            OperationResultStatus.NotFound => NotFound(ApiResult<TData>.Error(result.Message)),
            OperationResultStatus.Error => BadRequest(ApiResult<TData>.Error(result.Message)),
            _ => BadRequest(ApiResult<TData>.Error(result.Message))
        };
    }

    protected IActionResult QueryResult<TData>(TData? data)
    {
        if (data is null)
            return NotFound(ApiResult<TData>.Error("اطلاعات یافت نشد."));

        return Ok(ApiResult<TData>.Success(data, "عملیات با موفقیت انجام شد."));
    }
}