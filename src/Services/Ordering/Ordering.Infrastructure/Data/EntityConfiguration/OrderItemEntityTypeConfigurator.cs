using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Data.EntityConfiguration;

public class OrderItemEntityTypeConfigurator : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> orderItemConfiguration)
    {
        orderItemConfiguration.ToTable(nameof(OrderItem));

        orderItemConfiguration.HasKey(orderItem => orderItem.Id);

        orderItemConfiguration.Property(orderItem => orderItem.ProductName)
            .IsRequired()
            .HasMaxLength(100);

        orderItemConfiguration.Property(orderItem => orderItem.ImageUri)
            .IsRequired();

        orderItemConfiguration.Property(orderItem => orderItem.Price)
            .IsRequired();

        orderItemConfiguration.Property(orderItem => orderItem.Quantity)
            .IsRequired();

        orderItemConfiguration.Property(orderItem => orderItem.ProductId)
            .IsRequired();

        orderItemConfiguration.Property(orderItem => orderItem.OrderId)
            .IsRequired();

        orderItemConfiguration.HasOne<Order>()
            .WithMany(o => o.OrderItems)
            .HasForeignKey(orderItem => orderItem.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
