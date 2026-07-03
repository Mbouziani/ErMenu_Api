using ErMenu.Domain.Aggregates.Users.Entities;

namespace ErMenu.Domain.Aggregates.Users.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default);


    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

}