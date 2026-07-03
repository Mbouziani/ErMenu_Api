namespace ErMenu.Application.Common.DTOs.Users;

public sealed class ActorDto
{
    public int Id { get; set; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty; 
}