namespace ErMenu.Domain.Aggregates.Products.Entities;

public class Product
{
    private Product() { }

    public int CategoryId { get; private set; }
    public Category Category { get; } = null!;

    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public decimal Price { get; private set; }


}
