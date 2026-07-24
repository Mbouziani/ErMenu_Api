using ErMenu.Domain.Aggregates.Products.Entities;

namespace ErMenu.Application.Features.landings.Queries.GetAppLanding.DTOs;

public class CategoryDto
{ 
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public List<ProductDto> Products { get; set; } = [];

    public List<ProductAdditionDto> Additionals { get; set; } = [];




    public static CategoryDto FromEntity(Category category, List<ProductOffer> offers)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Products = [.. category.Products
                .Where(c => c.TypeId != 7)
                .Select(p => ProductDto.FromEntity(p, offers))],
            Additionals = [.. category.Products
                .Where(c => c.TypeId == 7)
                .Select(p => ProductAdditionDto.FromEntity(p, offers))],
        };
    }

}