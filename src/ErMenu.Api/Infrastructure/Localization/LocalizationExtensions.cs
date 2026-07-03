using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace ErMenu.Api.Infrastructure.Localization;

public static class LocalizationExtensions
{
    public static IServiceCollection AddLocalizationServices(
        this IServiceCollection services)
    {
        services.AddLocalization();

        services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[]
            {
            new CultureInfo("en"),
            new CultureInfo("ar"),
            new CultureInfo("fr")
        };

            options.DefaultRequestCulture = new RequestCulture("en");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;

            // Reads Accept-Language header
            options.RequestCultureProviders.Insert(
                0,
                new AcceptLanguageHeaderRequestCultureProvider());
        });

        return services;
    }
}