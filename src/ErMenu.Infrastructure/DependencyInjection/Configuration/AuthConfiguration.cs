using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ErMenu.Domain.Aggregates.Users.Exceptions;
using ErMenu.Infrastructure.AppSettignsDTOs;
using System.Security.Claims;
using System.Text;

namespace ErMenu.Infrastructure.DependencyInjection.Configuration;

public static class AuthConfiguration
{
    public static IServiceCollection AddJwtServices(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings").Get<TokenSettingsDto>()
            ?? throw UserExceptions.TokenInvalid();


        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.IncludeErrorDetails = true;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ClockSkew = TimeSpan.Zero,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                RoleClaimType = ClaimTypes.Role,
                NameClaimType = ClaimTypes.NameIdentifier
            };
            options.Events = new JwtBearerEvents
            {
                OnForbidden = context => throw UserExceptions.TokenInvalid(),
                OnChallenge = context => throw UserExceptions.TokenInvalid(),
                OnAuthenticationFailed = context => throw UserExceptions.TokenInvalid(),
            };
        });


        return services;
    }
}
