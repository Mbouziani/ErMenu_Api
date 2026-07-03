
using ErMenu.Application.Common.Interfaces;
using ErMenu.Domain.Aggregates.Orders.Entities;
using ErMenu.Domain.Aggregates.Products.Entities;
using ErMenu.Domain.Aggregates.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace ErMenu.Infrastructure.Persistence;


public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IUnitOfWork
{

    public DbSet<User> Users => Set<User>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();


    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderLine> OrderLines => Set<OrderLine>();

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> ProductCategories => Set<Category>();




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }


}