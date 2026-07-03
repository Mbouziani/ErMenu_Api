using ErMenu.Domain.Aggregates.Products.Entities;

namespace ErMenu.Application.Features.Products.Queries.GetCategoriesIncludeProducts;

public class CategoryDto
{


    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public List<ProductDto> Products { get;  set; } = [];
}
