namespace ErMenu.Application.Features.Products.Queries.GetCategoriesIncludeProducts;

public class ProductDto
{
    public int CategoryId { get; set; }
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
}
