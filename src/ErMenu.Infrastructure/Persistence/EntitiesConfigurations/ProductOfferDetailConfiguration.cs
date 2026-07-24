using ErMenu.Domain.Aggregates.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErMenu.Infrastructure.Persistence.EntitiesConfigurations;

internal class ProductOfferDetailConfiguration : IEntityTypeConfiguration<ProductOfferDetail>
{
    public void Configure(EntityTypeBuilder<ProductOfferDetail> builder)
    {
        builder.ToTable("Sales_PurchaseInvoicePriceOffersDetails");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnName("ID"); 

        builder.Property(x => x.ProductId)
               .HasColumnName("ItemID"); 

        builder.Property(x => x.SizeId)
              .HasColumnName("SizeID");


        builder.Property(x => x.MainOfferId)
               .HasColumnName("InvoiceID");


    }
}

