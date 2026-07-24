namespace ErMenu.Domain.Aggregates.Products.Entities;

public class ProductSize
{
    private ProductSize() { }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
}

