namespace ErMenu.Domain.Aggregates.Users.Entities;

public class RefreshToken
{
    private RefreshToken() { }

    public int Id { get; private set; }
    public int UserId { get; private set; }
    public User User { get; } = null!;

    public string TokenHash { get; private set; } = null!;

    public DateTimeOffset ExpiresAt { get; private set; }

    public DateTimeOffset? RevokedAt { get; private set; }



    public bool IsExpired => DateTimeOffset.UtcNow >= ExpiresAt;
    public bool IsRevoked => RevokedAt.HasValue;
    public bool IsActive => !IsRevoked && !IsExpired;


    public RefreshToken(
        int userId,
        string tokenHash,
        DateTimeOffset expiresAt)
    {
        UserId = userId;
        TokenHash = tokenHash;
        ExpiresAt = expiresAt;
    }

    public void Revoke()
    {
        if (IsRevoked)
            return;

        RevokedAt = DateTimeOffset.UtcNow;

    }
}