using ErMenu.Application.Common.Models.BaseResult;
using ErMenu.Domain.Aggregates.Products.Repositories;
using MediatR;

namespace ErMenu.Application.Features.Products.Queries.GetCategoriesIncludeProducts;

internal class GetCategoriesIncludeProductsQueryHandler(
    IProductRepository productRepository)
    : IRequestHandler<GetCategoriesIncludeProductsQuery, Result<List<CategoryDto>>>
{
    public async Task<Result<List<CategoryDto>>> Handle(
        GetCategoriesIncludeProductsQuery request,
        CancellationToken cancellationToken)
    {
        var categories = await productRepository
            .GetProductCategoriesIncludeProductsAsync(cancellationToken);

        var response = categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Products = c.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId
            }).ToList()
        }).ToList();

        return Result<List<CategoryDto>>.Success(response);
    }
}