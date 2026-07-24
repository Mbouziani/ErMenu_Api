using ErMenu.Domain.Aggregates.Users.Entities;

namespace ErMenu.Domain.Aggregates.Users.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<int?> GetCurrentSessionIdAsync(int userId, CancellationToken cancellationToken = default);
    Task<int> CreateNewSessionAsync(UserSession session, CancellationToken cancellationToken = default);

    Task<int?> GetMaxSessionIdAsync(int branchId, CancellationToken cancellationToken = default);

}