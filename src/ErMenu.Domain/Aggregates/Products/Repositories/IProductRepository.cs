using ErMenu.Domain.Aggregates.Products.Entities;

namespace ErMenu.Domain.Aggregates.Products.Repositories;

public interface IProductRepository
{
    Task<List<Category>> GetFullProductsNavigationAsync(CancellationToken cancellationToken = default);
    Task<List<ProductOffer>> GetProductOffersAsync(CancellationToken cancellationToken = default);
}
