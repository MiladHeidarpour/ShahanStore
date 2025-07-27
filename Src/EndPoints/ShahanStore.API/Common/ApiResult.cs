namespace ShahanStore.API.Common;

public class ApiResult
{
    public bool IsSuccess { get; protected set; }
    public string Message { get; protected set; }

    public static ApiResult Success(string message) => new() { IsSuccess = true, Message = message };
    public static ApiResult Error(string message) => new() { IsSuccess = false, Message = message };
    public static ApiResult NotFound(string message) => new() { IsSuccess = false, Message = message };
}

public class ApiResult<TData> : ApiResult
{
    public TData? Data { get; private set; }

    public static ApiResult<TData> Success(TData data, string message)
    {
        return new() { IsSuccess = true, Message = message, Data = data };
    }
    public static ApiResult<TData> Created(TData data)
    {
        return new() { IsSuccess = true, Message = "عملیات با موفقیت انجام شد", Data = data };
    }
    public static new ApiResult<TData> Error(string message)
    {
        return new() { IsSuccess = false, Message = message, Data = default };
    }
}