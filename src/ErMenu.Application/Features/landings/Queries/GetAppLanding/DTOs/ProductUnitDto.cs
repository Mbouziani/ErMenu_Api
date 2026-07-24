using ErMenu.Domain.Aggregates.Products.Entities;

namespace ErMenu.Application.Features.landings.Queries.GetAppLanding.DTOs;

public class ProductUnitDto
{
    public int Id { get; set; }
    public string Barecode { get; set; } = string.Empty;
    public string SizeName { get; set; } = string.Empty;
    public int SizeId { get; set; } 
    public int ProductId { get; set; }
    public double Price { get; set; }

    public double DiscountRate { get; set; }


    public static ProductUnitDto FromEntity(ProductUnit unit, int categoryId, List<ProductOffer> offers)
    {
        var discountRate = GetDiscountRate(
            offers,
            categoryId,
            unit.ProductId,
            unit.ProductSizeId);

        return new ProductUnitDto
        {
            Id = unit.Id,
            Barecode = unit.BareCode,
            SizeName = unit.ProductSize.Name,
            SizeId = unit.ProductSizeId,
            ProductId = unit.ProductId,
            Price = unit.Price,
            DiscountRate = discountRate,
        };
    }


    private static double GetDiscountRate(
       List<ProductOffer> offers,
       int categoryId,
       int productId,
       int sizeId)
    {
 

        var today = DateOnly.FromDateTime(DateTime.Today);

        foreach (var offer in offers)
        {


            // 1. Details
            if (offer.ProductOfferDetails.Any(d =>
                d.ProductId == productId &&
                d.SizeId == sizeId))
            {
                return offer.DiscountRate;
            }

            // 2. Product + Size
            if (offer.FromProductId != 0 &&
                productId >= offer.FromProductId &&
                productId <= offer.ToProductId &&
                offer.FromSizeId != 0 &&
                sizeId >= offer.FromSizeId &&
                sizeId <= offer.ToSizeId)
            {
                return offer.DiscountRate;
            }

            // 3. Product only
            if (offer.FromProductId != 0 &&
                productId >= offer.FromProductId &&
                productId <= offer.ToProductId &&
                offer.FromSizeId == 0)
            {
                return offer.DiscountRate;
            }

            // 4. Category
            if (offer.FromProductId == 0 &&
                categoryId >= offer.FromGategoryId &&
                categoryId <= offer.ToGategoryId)
            {
                return offer.DiscountRate;
            }
        }

        return 0;
    }
}
