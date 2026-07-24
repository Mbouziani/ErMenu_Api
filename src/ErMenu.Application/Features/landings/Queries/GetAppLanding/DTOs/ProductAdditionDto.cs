using ErMenu.Domain.Aggregates.Products.Entities;

namespace ErMenu.Application.Features.landings.Queries.GetAppLanding.DTOs;



public class ProductAdditionDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int CategoryId { get; set; }
    public ProductUnitDto Unit { get; set; } = null!;

    public static ProductAdditionDto FromEntity(Product product, List<ProductOffer> offers)
    {
        return new ProductAdditionDto
        {
            Id = product.Id,
            Name = product.Name,
            CategoryId = product.CategoryId,
            Unit = ProductUnitDto.FromEntity(product.Units.First(), product.CategoryId, offers),
        };
    }
}
