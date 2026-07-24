using ErMenu.Domain.Aggregates.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErMenu.Infrastructure.Persistence.EntitiesConfigurations;

internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Stc_ItemsGroups");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnName("GroupID");

        builder.Property(x => x.Name)
               .HasColumnName("ArbName");

        builder.Property(x => x.Cancel)
              .HasColumnName("Cancel");

        builder.HasQueryFilter(x => x.Cancel == 0);

    }
}