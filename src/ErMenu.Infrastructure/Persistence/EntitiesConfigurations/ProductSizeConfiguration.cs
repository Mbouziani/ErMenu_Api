using ErMenu.Domain.Aggregates.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

namespace ErMenu.Infrastructure.Persistence.EntitiesConfigurations;

internal class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
{
    public void Configure(EntityTypeBuilder<ProductSize> builder)
    {
        builder.ToTable("Stc_SizingUnits");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnName("SizeID");

        builder.Property(x => x.Name)
               .HasColumnName("ArbName");
    }
}