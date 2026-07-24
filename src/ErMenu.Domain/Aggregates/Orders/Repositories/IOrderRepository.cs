using ErMenu.Domain.Aggregates.Orders.Entities;

namespace ErMenu.Domain.Aggregates.Orders.Repositories;

public interface IOrderRepository
{
 

    Task<string> InsertUsingXmlAsync(Sales_SalesInvoiceMaster order, CancellationToken cancellationToken = default); 

}
