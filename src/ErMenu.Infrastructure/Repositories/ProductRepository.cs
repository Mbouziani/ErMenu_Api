using ErMenu.Domain.Aggregates.Products.Entities;
using ErMenu.Domain.Aggregates.Products.Repositories;
using ErMenu.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ErMenu.Infrastructure.Repositories;

internal class ProductRepository(AppDbContext context) : IProductRepository
{ 
    public async Task<List<Category>> GetProductCategoriesIncludeProductsAsync(
        CancellationToken cancellationToken = default)
    {
        return await context.ProductCategories
            .Include(c => c.Products)
            .ToListAsync(cancellationToken);
    }
}
