namespace Common.Application.Models.Results;

public class OperationResult
{
    protected OperationResult(string message, OperationResultStatus status)
    {
        Message = message;
        Status = status;
    }

    public string Message { get; private set; }
    public OperationResultStatus Status { get; private set; }


    public static OperationResult Success(string message = "عملیات با موفقیت انجام شد")
    {
        return new OperationResult(message, OperationResultStatus.Success);
    }

    public static OperationResult Warning(string message = "هشدار!")
    {
        return new OperationResult(message, OperationResultStatus.Warning);
    }

    public static OperationResult Error(string message = "عملیات با شکست مواجه شد")
    {
        return new OperationResult(message, OperationResultStatus.Error);
    }

    public static OperationResult NotFound(string message = "اطلاعات یافت نشد")
    {
        return new OperationResult(message, OperationResultStatus.NotFound);
    }
}

public class OperationResult<TData> : OperationResult
{
    private OperationResult(string message, OperationResultStatus status, TData? data)
        : base(message, status)
    {
        Data = data;
    }

    public TData? Data { get; private set; }

    public static OperationResult<TData> Success(TData data, string message = "عملیات با موفقیت انجام شد")
    {
        return new OperationResult<TData>(message, OperationResultStatus.Success, data);
    }

    public new static OperationResult<TData> Warning(string message = "هشدار!")
    {
        return new OperationResult<TData>(message, OperationResultStatus.Warning, default);
    }

    public new static OperationResult<TData> Error(string message = "عملیات با شکست مواجه شد")
    {
        return new OperationResult<TData>(message, OperationResultStatus.Error, default);
    }

    public new static OperationResult<TData> NotFound(string message = "اطلاعات یافت نشد")
    {
        return new OperationResult<TData>(message, OperationResultStatus.NotFound, default);
    }
}

public enum OperationResultStatus
{
    Success,
    Error,
    NotFound,
    Warning
}