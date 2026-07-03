namespace ErMenu.Api.Common.Response;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string ErrorCode { get; set; } = null!;
    public string Message { get; set; } = null!;
    public bool IsSuccess { get; set; } = false;
}