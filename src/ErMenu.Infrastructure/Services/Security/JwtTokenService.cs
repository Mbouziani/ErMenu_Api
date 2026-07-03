using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ErMenu.Application.Common.DTOs.Auth;
using ErMenu.Application.Common.Interfaces.Security;
using ErMenu.Domain.Aggregates.Users.Entities;
using ErMenu.Infrastructure.AppSettignsDTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace ErMenu.Infrastructure.Services.Security;

public class JwtTokenService(IOptions<TokenSettingsDto> tokenSettingsDto) : IJwtTokenService
{


    private const int RefreshTokenSize = 64;
    private const int PasswordResetTokenSize = 32;


    private readonly TokenSettingsDto _settings = tokenSettingsDto.Value;
     
    public TokenDto GenerateLoginTokens(User user)
    {
        var accessTokenExpires = DateTimeOffset.UtcNow.AddMinutes(_settings.AccessTokenExpiryMinutes);
        var refreshTokenExpires = DateTimeOffset.UtcNow.AddDays(_settings.RefreshTokenExpiryDays);

        var accessToken = GenerateAccessToken(user, accessTokenExpires);
        var refreshToken = GenerateRefreshToken();

        return new TokenDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            AccessTokenExpiresAt = accessTokenExpires,
            RefreshTokenExpiresAt = refreshTokenExpires
        };
    }
   

    private string GenerateAccessToken(User user, DateTimeOffset expiresAt)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Name, user.FirstName + " " + user.LastName),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            claims: claims,
            expires: expiresAt.UtcDateTime,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static string GenerateRefreshToken()
    {
        return GenerateSecureToken(RefreshTokenSize);
    }

    public string GeneratePasswordResetToken()
    {
        return GenerateSecureToken(PasswordResetTokenSize);
    }
    

    private static string GenerateSecureToken(int byteLength)
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(byteLength));
    }

    public string Hash(string token)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(token));
        return Convert.ToHexString(bytes);
    }
     
}

