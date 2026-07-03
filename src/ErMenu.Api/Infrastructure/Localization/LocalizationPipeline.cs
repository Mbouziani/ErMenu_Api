using Microsoft.Extensions.Options;

namespace ErMenu.Api.Infrastructure.Localization;

public static class LocalizationPipeline
{
    public static IApplicationBuilder UseAppLocalization(this IApplicationBuilder app)
    {
        return app.UseRequestLocalization(
            app.ApplicationServices
                .GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
    }
}