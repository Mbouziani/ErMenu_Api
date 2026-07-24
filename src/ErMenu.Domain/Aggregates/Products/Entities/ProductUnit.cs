namespace ErMenu.Domain.Aggregates.Products.Entities;

public class ProductUnit
{
    private ProductUnit() { }

    public int ProductId { get; private set; }
    public Product Product { get; } = null!;


    public int ProductSizeId { get; private set; }
    public virtual ProductSize ProductSize { get; private set; } = null!;

    public int Id { get; private set; }

    public string BareCode { get; private set; } = string.Empty;
    public double Price { get; private set; }
}
