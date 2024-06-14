namespace Ordering.Domain.Entities;

public class Order
{
    public required string Id { get; set; }

    public required string BuyerId { get; set; }

    public required string Description { get; set; }

    public List<OrderItem> OrderItems { get; set; } = [];

    public OrderState State { get; set; } = OrderState.Configuring;
}

public enum OrderState
{
    Configuring,
    AwaitingValidation,
    Confirmed,
    Shipped,
    Canceled
}
