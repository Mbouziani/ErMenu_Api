using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ErMenu.Infrastructure.Persistence;

namespace ErMenu.Infrastructure.DependencyInjection.Configuration;

public static class DbContextConfiguration
{
    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("Default")
           ?? throw new InvalidOperationException("Database connection string is missing.");

        services.AddDbContext<AppDbContext>((sp, options) =>
        {
            options.UseSqlServer(connectionString);
        });

        return services;
    }
}
