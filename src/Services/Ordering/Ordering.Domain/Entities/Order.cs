using Ordering.Domain.Enums;

namespace Ordering.Domain.Entities;

public class Order
{
    required public string Id { get; set; }

    required public string BuyerId { get; set; }

    required public string Description { get; set; }

    public List<OrderItem> OrderItems { get; set; } = [];

    public OrderState State { get; set; } = OrderState.Configuring;
}
