using ErMenu.Api.Infrastructure.Cors;
using ErMenu.Api.Infrastructure.Localization;
using ErMenu.Api.Middleware.Exceptions;
using ErMenu.Api.Middleware.Logging;
using ErMenu.Api.Middleware.Security; 

namespace ErMenu.Api.DependencyInjection;

public static class ApiPipeline
{
    public static WebApplication UseApiPipeline(this WebApplication app)
    {
        // 1. SECURITY HEADERS (always first response modifier)
        app.UseSecurityHeaders();

        // 2. HTTPS REDIRECTION (early redirect)
        app.UseHttpsRedirection();

        // 3. EXCEPTION HANDLING (wrap everything below)
        app.UseExceptionMiddleware();

        // 4. REQUEST LOGGING (after exception wrapper)
        app.UseRequestLoggingMiddleware();

        // 5. CORS (before auth)
        app.UseCors(CorsPolicies.Default);

        // 6. LOCALIZATION
        app.UseAppLocalization();

        // 7. RATE LIMITING (protect endpoints early)
        app.UseRateLimiter();

        app.UseStaticFiles();

        // 8. AUTHENTICATION
        app.UseAuthentication();

        // 9. AUTHORIZATION
        app.UseAuthorization();

        // 10. CONTROLLERS
        app.MapControllers();

        return app;
    }
}