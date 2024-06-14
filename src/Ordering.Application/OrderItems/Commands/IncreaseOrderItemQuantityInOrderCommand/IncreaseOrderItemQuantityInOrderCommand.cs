namespace Ordering.Application.OrderItems.Commands.IncreaseOrderItemQuantityInOrderCommand;

public class IncreaseOrderItemQuantityInOrderCommand
{
    public required string OrderItemId { get; set; }

    public required int Quantity { get; set; }
}
