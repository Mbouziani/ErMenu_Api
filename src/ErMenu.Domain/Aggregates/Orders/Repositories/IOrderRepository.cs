using ErMenu.Domain.Aggregates.Orders.Entities;

namespace ErMenu.Domain.Aggregates.Orders.Repositories;

public interface IOrderRepository
{
    Task<int> GetLastOrderNumberAsync(CancellationToken cancellationToken = default);
    Task<Order?> GetOrderIncludeLinesByIdAsync(int id, CancellationToken cancellationToken = default);

    IQueryable<Order> QueryNoTracking(bool ignoreQueryFilters = false);
    IQueryable<Order> Query(bool ignoreQueryFilters = false);


    Task AddAsync(Order order, CancellationToken cancellationToken = default);

}
