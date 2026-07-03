namespace ErMenu.Domain.Aggregates.Users.Entities;

public class User
{
    private User() { }


    public int Id { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string? PhoneNumber { get; private set; }

    public string PasswordHash { get; private set; } = null!;

    public ICollection<RefreshToken> RefreshTokens { get; private set; } = [];



}
