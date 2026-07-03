namespace ErMenu.Application.Common.Models.BaseResult;

public class Result<T>
{
    public int StatusCode { get; set; }
    public bool IsSuccess { get; private set; }

    public string Message { get; private set; } = string.Empty;

    public T? Data { get; private set; }

    public static Result<T> Success(
        T data,
        string message = "Success")
    {
        return new Result<T>
        {
            IsSuccess = true,
            Message = message,
            Data = data
        };
    }
}