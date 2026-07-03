namespace ErMenu.Application.Common.DTOs.Auth;

public sealed class TokenDto
{
    public string AccessToken { get; init; } = null!;
    public string RefreshToken { get; init; } = null!;
    public DateTimeOffset AccessTokenExpiresAt { get; init; }
    public DateTimeOffset RefreshTokenExpiresAt { get; init ; }
}