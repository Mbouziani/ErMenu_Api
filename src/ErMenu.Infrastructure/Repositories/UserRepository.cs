using Microsoft.EntityFrameworkCore;
using ErMenu.Domain.Aggregates.Users.Entities; 
using ErMenu.Domain.Aggregates.Users.Repositories; 
using ErMenu.Infrastructure.Persistence;

namespace ErMenu.Infrastructure.Repositories;

internal class UserRepository(AppDbContext context) : IUserRepository

{
    

    public async Task<User?> GetByEmailAsync(
    string email,
    CancellationToken cancellationToken)
    {
        return await context.Users
            .FirstOrDefaultAsync(
                x => x.Email == email,
                cancellationToken);
    }

    public async Task<User?> GetByIdAsync(
      int id,
      CancellationToken cancellationToken)
    {
        return await context.Users
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }
      
}
