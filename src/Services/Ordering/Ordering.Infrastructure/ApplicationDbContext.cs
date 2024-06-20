using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Data.EntityConfiguration;

namespace Ordering.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders => Set<Order>();

    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    public DbSet<Buyer> Users => Set<Buyer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfigurator());
        modelBuilder.ApplyConfiguration(new OrderItemEntityTypeConfigurator());
        modelBuilder.ApplyConfiguration(new UserEntityTypeConfigurator());

        base.OnModelCreating(modelBuilder);
    }
}
