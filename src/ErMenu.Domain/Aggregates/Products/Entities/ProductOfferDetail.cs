namespace ErMenu.Domain.Aggregates.Products.Entities;

public class ProductOfferDetail
{
    private ProductOfferDetail() { }

    public int MainOfferId { get; private set; }
    public ProductOffer MainOffer { get; } = null!;

    public int Id { get; private set; }

    public int ProductId { get; private set; }
    public int SizeId { get; private set; } 


}
