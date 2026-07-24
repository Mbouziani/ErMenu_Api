using ErMenu.Domain.Aggregates.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErMenu.Infrastructure.Persistence.EntitiesConfigurations;

internal class ProductUnitConfiguration : IEntityTypeConfiguration<ProductUnit>
{
    public void Configure(EntityTypeBuilder<ProductUnit> builder)
    {
        builder.ToTable("Stc_ItemUnits");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnName("ID");

        builder.Property(x => x.ProductId)
               .HasColumnName("ItemID");

        builder.Property(x => x.ProductSizeId)
               .HasColumnName("SizeID");

        builder.Property(x => x.BareCode)
               .HasColumnName("BarCode");

        builder.Property(x => x.Price)
               .HasColumnName("SalePrice");
    }
}