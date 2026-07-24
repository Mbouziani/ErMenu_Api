namespace ErMenu.Application.Common.DTOs.Users;

public sealed class UserProfileDto
{
    public int Id { get; init; }
    public string FullName { get; init; } = string.Empty;
}