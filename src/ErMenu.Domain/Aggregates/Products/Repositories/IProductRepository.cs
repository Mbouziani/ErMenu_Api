using ErMenu.Domain.Aggregates.Products.Entities;

namespace ErMenu.Domain.Aggregates.Products.Repositories;

public interface IProductRepository
{
    Task<List<Category>> GetProductCategoriesIncludeProductsAsync(CancellationToken cancellationToken = default);

}
