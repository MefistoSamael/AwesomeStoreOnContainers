using MediatR;

namespace Ordering.Application.OrderItems.Commands.DecreaseOrderItemQuantityInOrderCommand;

public class DecreaseOrderItemQuantityInOrderCommand : IRequest
{
    required public string OrderItemId { get; set; }

    required public int NewQuantity { get; set; }
}
