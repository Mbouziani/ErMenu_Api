namespace ErMenu.Domain.Aggregates.Products.Entities;

public class Category
{

    private Category() { }


    public int Id { get; private set; }
    public string Name { get; private set; } = null!;

    public int Cancel { get; private set; }


    public ICollection<Product> Products { get; private set; } = [];


}
