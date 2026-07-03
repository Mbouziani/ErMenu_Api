using ErMenu.Domain.Aggregates.Orders.Entities;
using ErMenu.Domain.Aggregates.Orders.Repositories;
using ErMenu.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ErMenu.Infrastructure.Repositories;

internal class OrderRepository(AppDbContext context) : IOrderRepository
{
    public async Task AddAsync(Order order, CancellationToken cancellationToken = default)
    {
        await context.Orders.AddAsync(order, cancellationToken);
    }
    public async Task<int> GetLastOrderNumberAsync(CancellationToken cancellationToken = default)
    {
        return await context.Orders
            .Select(o => (int?)o.Id)
            .MaxAsync(cancellationToken) ?? 0;
    }

    public async Task<Order?> GetOrderIncludeLinesByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Orders.Include(o => o.Lines)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
     
    public IQueryable<Order> Query(bool ignoreQueryFilters = false)
    {
        var query = context.Orders.AsQueryable();

        if (ignoreQueryFilters)
            query = query.IgnoreQueryFilters();

        return query;
    }

    public IQueryable<Order> QueryNoTracking(bool ignoreQueryFilters = false)
    {
        var query = context.Orders
            .AsNoTracking()
            .AsQueryable();

        if (ignoreQueryFilters)
            query = query.IgnoreQueryFilters();

        return query;
    }


}
