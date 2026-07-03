namespace ErMenu.Api.Middleware.Logging;

public class RequestLoggingMiddleware(
    RequestDelegate next,
    ILogger<RequestLoggingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var start = DateTime.UtcNow;

        var request = context.Request;

        logger.LogInformation(
            "HTTP {Method} {Path} started",
            request.Method,
            request.Path);

        await next(context);

        var duration = DateTime.UtcNow - start;

        logger.LogInformation(
            "HTTP {Method} {Path} finished in {Duration} ms with {StatusCode}",
            request.Method,
            request.Path,
            duration.TotalMilliseconds,
            context.Response.StatusCode);
    }
}