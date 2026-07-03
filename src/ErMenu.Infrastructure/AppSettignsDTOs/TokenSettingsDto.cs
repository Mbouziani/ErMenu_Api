namespace ErMenu.Infrastructure.AppSettignsDTOs;

public sealed record TokenSettingsDto
{
    public string Issuer { get; init; } = string.Empty;

    public string Audience { get; init; } = string.Empty;

    public string Key { get; init; } = string.Empty;

    public int AccessTokenExpiryMinutes { get; init; } = 5;

    public int RefreshTokenExpiryDays { get; init; } = 7;
}