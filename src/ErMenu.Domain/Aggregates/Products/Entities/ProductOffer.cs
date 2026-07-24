namespace ErMenu.Domain.Aggregates.Products.Entities;

public class ProductOffer
{
    private ProductOffer() { }

    public int Id { get; private set; }
    public string Description { get; private set; } = string.Empty;

    public double DiscountRate { get; private set; }

    public double FromDate { get; private set; }
    public double ToDate { get; private set; }

    public int FromGategoryId { get; private set; }
    public int ToGategoryId { get; private set; }

    public int FromProductId { get; private set; }
    public int ToProductId { get; private set; }

    public int FromSizeId { get; private set; }
    public int ToSizeId { get; private set; }

    public ICollection<ProductOfferDetail> ProductOfferDetails { get; private set; } = [];

}
