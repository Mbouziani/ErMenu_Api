namespace ErMenu.Domain.Aggregates.Users.Entities;

public class User
{
    private User() { }

    
    public int Id { get; private set; }
    public int BranchID { get; private set; }
    public string FullName { get; private set; } = string.Empty; 

    public string PasswordHash { get; private set; } = null!;

    public ICollection<RefreshToken> RefreshTokens { get; } = [];

}
