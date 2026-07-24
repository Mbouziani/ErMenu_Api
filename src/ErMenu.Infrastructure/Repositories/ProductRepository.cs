using ErMenu.Domain.Aggregates.Products.Entities;
using ErMenu.Domain.Aggregates.Products.Repositories;
using ErMenu.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ErMenu.Infrastructure.Repositories;

internal class ProductRepository(AppDbContext context) : IProductRepository
{
    

    public async Task<List<Category>> GetFullProductsNavigationAsync(CancellationToken cancellationToken = default)
    {
        return await context.ProductCategories
            .Include(c => c.Products).ThenInclude(p => p.Units).ThenInclude(u => u.ProductSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<ProductOffer>> GetProductOffersAsync(CancellationToken cancellationToken = default)
    {
        var today = DateTime.Today.Year * 10000
                  + DateTime.Today.Month * 100
                  + DateTime.Today.Day;
        
        return await context.ProductOffers
             .Where(po => po.FromDate <= today && po.ToDate >= today)
            .Include(po => po.ProductOfferDetails) 
            .ToListAsync(cancellationToken);
    }
}
