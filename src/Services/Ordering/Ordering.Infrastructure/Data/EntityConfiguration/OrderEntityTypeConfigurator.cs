﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Data.EntityConfiguration;

public class OrderEntityTypeConfigurator : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> orderConfiguration)
    {
        orderConfiguration.ToTable("Order");

        orderConfiguration.HasKey(order => order.Id);

        orderConfiguration.Property(order => order.BuyerId)
            .IsRequired();

        orderConfiguration.HasMany(order => order.OrderItems)
            .WithOne()
            .HasForeignKey(orderItem => orderItem.OrderId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}
