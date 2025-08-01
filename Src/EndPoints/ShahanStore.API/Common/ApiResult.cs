using Common.Application.Models.Results;

namespace ShahanStore.API.Common;

public class ApiResult
{
    public string Message { get; protected set; }
    public OperationResultStatus Status { get; protected set; }
    public bool IsSuccess { get; protected set; }

    public static ApiResult Success(string message)
    {
        return new ApiResult { IsSuccess = true, Message = message, Status = OperationResultStatus.Success };
    }

    public static ApiResult Error(string message)
    {
        return new ApiResult { IsSuccess = false, Message = message, Status = OperationResultStatus.Error };
    }

    public static ApiResult NotFound(string message)
    {
        return new ApiResult { IsSuccess = false, Message = message, Status = OperationResultStatus.NotFound };
    }
}

public class ApiResult<TData> : ApiResult
{
    public TData? Data { get; private set; }

    public static ApiResult<TData> Success(TData data, string message)
    {
        return new ApiResult<TData>
            { IsSuccess = true, Message = message, Data = data, Status = OperationResultStatus.Success };
    }

    public static ApiResult<TData> Error(string message)
    {
        return new ApiResult<TData>
            { IsSuccess = false, Message = message, Data = default, Status = OperationResultStatus.Error };
    }
}