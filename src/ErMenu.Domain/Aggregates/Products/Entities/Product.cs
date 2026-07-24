namespace ErMenu.Domain.Aggregates.Products.Entities;

public class Product
{
    private Product() { }

    public int CategoryId { get; private set; }
    public Category Category { get; } = null!;

    public int TypeId { get; private set; }

    public int Id { get; private set; }
    public string Name { get; private set; } = null!;

    public int? Cancel { get; private set; }




    public ICollection<ProductUnit> Units { get; private set; } = [];

}
