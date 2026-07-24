using ErMenu.Domain.Aggregates.Products.Entities;

namespace ErMenu.Application.Features.landings.Queries.GetAppLanding.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int CategoryId { get; set; }   
    public List<ProductUnitDto> Units { get; set; } = [];


    public static ProductDto FromEntity(Product product, List<ProductOffer> offers)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            CategoryId = product.CategoryId,
            Units = [.. product.Units.Select(u => ProductUnitDto.FromEntity(u, product.CategoryId, offers))],
        };
    }

}
