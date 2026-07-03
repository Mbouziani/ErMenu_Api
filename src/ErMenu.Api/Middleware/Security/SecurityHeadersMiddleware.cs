namespace ErMenu.Api.Middleware.Security;

public class SecurityHeadersMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var headers = context.Response.Headers;

        // Prevent MIME sniffing
        headers.XContentTypeOptions = "nosniff";

        // Prevent clickjacking
        headers.XFrameOptions = "DENY";

        // XSS protection (legacy but still ok to include)
        headers.XXSSProtection = "0";

        // Control referrer leakage
        headers["Referrer-Policy"] = "no-referrer";

        // Permissions policy (disable dangerous browser APIs)
        headers["Permissions-Policy"] =
            "camera=(), microphone=(), geolocation=(), payment=()";

        // Strong Content Security Policy (VERY important)
        headers.ContentSecurityPolicy =
            "default-src 'self'; " +
            "object-src 'none'; " +
            "frame-ancestors 'none';";

        // HSTS (ONLY in production HTTPS)
        if (context.Request.IsHttps)
        {
            headers.StrictTransportSecurity =
                "max-age=31536000; includeSubDomains; preload";
        }

        await next(context);
    }
}