namespace Ordering.Application.OrderItems.Commands.IncreaseOrderItemQuantityInOrderCommand;

public class IncreaseOrderItemQuantityInOrderCommand
{
    required public string OrderItemId { get; set; }

    required public int Quantity { get; set; }
}
