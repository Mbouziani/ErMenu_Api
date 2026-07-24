using Microsoft.EntityFrameworkCore;
using ErMenu.Domain.Aggregates.Users.Entities; 
using ErMenu.Domain.Aggregates.Users.Repositories; 
using ErMenu.Infrastructure.Persistence;

namespace ErMenu.Infrastructure.Repositories;

internal class UserRepository(AppDbContext context) : IUserRepository
{
  

    public async Task<User?> GetByIdAsync(
      int id,
      CancellationToken cancellationToken)
    {
        return await context.Users
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task<int?> GetCurrentSessionIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        FormattableString query = $@"SELECT TOP (1) SesionID AS Value FROM Sales_Open_Cashier WHERE UserID = {userId} AND Statuse = 0";


        return await context.Database
                .SqlQuery<int?>(query)
                .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<int> CreateNewSessionAsync(UserSession session, CancellationToken cancellationToken = default)
    {
        var query = session.BuildInsertQuery();
        return await context.Database.ExecuteSqlAsync(query, cancellationToken);
    }


    public async Task<int?> GetMaxSessionIdAsync(int branchId, CancellationToken cancellationToken = default)
    {
        FormattableString query = $@"SELECT MAX(SesionID) AS Value FROM Sales_Open_Cashier WHERE BranchID = {branchId}";
        return await context.Database
                .SqlQuery<int?>(query)
                .FirstOrDefaultAsync(cancellationToken);
    }


   
}
