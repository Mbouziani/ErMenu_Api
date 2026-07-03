namespace ErMenu.Api.Middleware.Logging;

public static class RequestLoggingExtensions
{
    public static IApplicationBuilder UseRequestLoggingMiddleware(
        this IApplicationBuilder app)
    {
        return app.UseMiddleware<RequestLoggingMiddleware>();
    }
}