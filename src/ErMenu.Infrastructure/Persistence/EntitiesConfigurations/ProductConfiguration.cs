using ErMenu.Domain.Aggregates.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErMenu.Infrastructure.Persistence.EntitiesConfigurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Stc_Items"); 

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnName("ItemID");

        builder.Property(x => x.Name)
               .HasColumnName("ArbName");

        builder.Property(x => x.Name)
               .HasColumnName("ArbName");

        builder.Property(x => x.TypeId)
               .HasColumnName("TypeID");

        builder.Property(x => x.Cancel)
               .HasColumnName("Cancel");


        builder.Property(x => x.CategoryId)
               .HasColumnName("GroupID");

        builder.HasQueryFilter(x => x.Cancel == null || x.Cancel == 0);
    }
}