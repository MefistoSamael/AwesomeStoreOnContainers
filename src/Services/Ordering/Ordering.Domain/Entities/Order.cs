using Ordering.Domain.Enums;

namespace Ordering.Domain.Entities;

public class Order : Entity
{
    required public string BuyerId { get; set; }

    public List<OrderItem> OrderItems { get; set; } = [];

    public OrderState State { get; set; } = OrderState.Configuring;
}
