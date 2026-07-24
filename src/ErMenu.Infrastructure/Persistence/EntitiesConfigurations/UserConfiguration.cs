using ErMenu.Domain.Aggregates.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErMenu.Infrastructure.Persistence.EntitiesConfigurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnName("UserID");

        builder.Property(x => x.FullName)
               .HasColumnName("ArbName");

        builder.Property(x => x.BranchID)
               .HasColumnName("BranchID"); 


        builder.Property(x => x.PasswordHash)
               .HasColumnName("Password");

        builder.HasMany(x => x.RefreshTokens)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}