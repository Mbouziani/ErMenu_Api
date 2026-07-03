using Microsoft.EntityFrameworkCore;
using ErMenu.Domain.Aggregates.Users.Entities;
using ErMenu.Domain.Aggregates.Users.Repositories;
using ErMenu.Infrastructure.Persistence;

namespace ErMenu.Infrastructure.Repositories;

internal class RefreshTokenRepository(AppDbContext context) : IRefreshTokenRepository
{
    public async Task AddAsync(RefreshToken refreshToken, CancellationToken cancellationToken = default)
    {
        await context.RefreshTokens.AddAsync(refreshToken, cancellationToken);
    }

    public async Task<IEnumerable<RefreshToken>> GetActiveTokensByUserIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await context.RefreshTokens
            .Include(x => x.User)
            .Where(x => x.UserId == userId && DateTimeOffset.UtcNow < x.ExpiresAt && !x.RevokedAt.HasValue)
            .ToListAsync(cancellationToken);
    }

    public async Task<RefreshToken?> GetByRefreshTokenAsync(string tokenHash, CancellationToken cancellationToken = default)
    {
        return await context.RefreshTokens
            .FirstOrDefaultAsync(x => x.TokenHash == tokenHash, cancellationToken);
    }

    public async Task<RefreshToken?> GetByRefreshTokenIncludedUserAsync(string tokenHash, CancellationToken cancellationToken = default)
    {
        return await context.RefreshTokens
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.TokenHash == tokenHash, cancellationToken);
    }
}
