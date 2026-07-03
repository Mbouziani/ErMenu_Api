using ErMenu.Application.Common.Interfaces;
using ErMenu.Application.Common.Interfaces.Security;
using ErMenu.Domain.Aggregates.Orders.Repositories;
using ErMenu.Domain.Aggregates.Products.Repositories;
using ErMenu.Domain.Aggregates.Users.Repositories;
using ErMenu.Infrastructure.AppSettignsDTOs;
using ErMenu.Infrastructure.Persistence;
using ErMenu.Infrastructure.Repositories;
using ErMenu.Infrastructure.Services.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ErMenu.Infrastructure.DependencyInjection.Configuration;

public static class InterfacesConfiguration
{
    public static IServiceCollection AddInterfacesRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TokenSettingsDto>(configuration.GetSection("JwtSettings"));


        // (IServices, Services) 
        services.AddScoped<ICurrentActor, CurrentActor>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<IPasswordService, PasswordService>();

        // (IUnitOfWork, UnitOfWork)
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // (IRepositories, Repositories)
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
