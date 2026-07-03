using ErMenu.Domain.Aggregates.Users.Entities;

namespace ErMenu.Domain.Aggregates.Users.Repositories;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByRefreshTokenAsync(string tokenHash, CancellationToken cancellationToken = default);
    Task<RefreshToken?> GetByRefreshTokenIncludedUserAsync(string tokenHash, CancellationToken cancellationToken = default);
    Task<IEnumerable<RefreshToken>> GetActiveTokensByUserIdAsync(int userId, CancellationToken cancellationToken = default);


    Task AddAsync(RefreshToken refreshToken, CancellationToken cancellationToken = default);
}