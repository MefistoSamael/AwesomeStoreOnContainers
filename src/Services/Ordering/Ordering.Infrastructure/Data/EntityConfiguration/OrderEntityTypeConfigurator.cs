using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Data.EntityConfiguration;

public class OrderEntityTypeConfigurator : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> orderConfiguration)
    {
        orderConfiguration.ToTable(nameof(Order));

        orderConfiguration.HasKey(order => order.Id);

        orderConfiguration.Property(order => order.BuyerId)
            .IsRequired();

        orderConfiguration.Property(order => order.Description)
            .IsRequired();

        orderConfiguration.HasMany(order => order.OrderItems)
            .WithOne()
            .HasForeignKey("OrderId")  
            .OnDelete(DeleteBehavior.Cascade);
    }
}
