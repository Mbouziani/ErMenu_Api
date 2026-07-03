using ErMenu.Infrastructure.DependencyInjection.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ErMenu.Infrastructure.DependencyInjection;

public static class InfrastructureDependencies
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationDbContext(configuration);

        services.AddInterfacesRegistration(configuration);
        services.AddJwtServices(configuration); 

        return services;
         
    }
}