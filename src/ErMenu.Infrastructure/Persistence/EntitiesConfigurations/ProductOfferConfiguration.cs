using ErMenu.Domain.Aggregates.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErMenu.Infrastructure.Persistence.EntitiesConfigurations;

internal class ProductOfferConfiguration : IEntityTypeConfiguration<ProductOffer>
{
    public void Configure(EntityTypeBuilder<ProductOffer> builder)
    {
        builder.ToTable("PriceItemsOffers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnName("OfferID");

        builder.Property(x => x.Description)
               .HasColumnName("Description");

        builder.Property(x => x.FromGategoryId)
               .HasColumnName("FromGroupID");

        builder.Property(x => x.ToGategoryId)
               .HasColumnName("ToGroupID");

        builder.Property(x => x.FromProductId)
              .HasColumnName("FromItemID");

        builder.Property(x => x.ToProductId)
               .HasColumnName("ToItemID");

        builder.Property(x => x.FromSizeId)
              .HasColumnName("FromSizeID");

        builder.Property(x => x.ToSizeId)
               .HasColumnName("ToISizeID");

        builder.Property(x => x.FromDate)
            .HasColumnName("FromDate");

        builder.Property(x => x.ToDate)
               .HasColumnName("ToDate");

        builder.Property(x => x.DiscountRate)
               .HasColumnName("PercentCost");


        builder.HasMany(x => x.ProductOfferDetails)
           .WithOne(x => x.MainOffer)
           .HasForeignKey(x => x.MainOfferId)
           .HasPrincipalKey(x => x.Id)
           .OnDelete(DeleteBehavior.NoAction);

    }
}

