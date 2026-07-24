using ErMenu.Domain.Aggregates.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErMenu.Infrastructure.Persistence.EntitiesConfigurations;

internal sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens");

        builder.HasKey(x => x.Id)
               .HasName("PK_RefreshTokens");

        builder.Property(x => x.Id)
               .HasColumnName("Id")
               .UseIdentityColumn();

        builder.Property(x => x.UserId)
               .HasColumnName("UserId")
               .IsRequired();

        builder.Property(x => x.TokenHash)
               .HasColumnName("TokenHash")
               .IsRequired();

        builder.Property(x => x.ExpiresAt)
               .HasColumnName("ExpiresAt")
               .HasColumnType("datetimeoffset")
               .IsRequired();

        builder.Property(x => x.RevokedAt)
               .HasColumnName("RevokedAt")
               .HasColumnType("datetimeoffset");

        builder.HasOne(x => x.User)
               .WithMany(x => x.RefreshTokens)
               .HasForeignKey(x => x.UserId)
               .HasConstraintName("FK_RefreshTokens_Users_UserId")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.UserId)
               .HasDatabaseName("IX_RefreshTokens_UserId");
   
         
    }
}