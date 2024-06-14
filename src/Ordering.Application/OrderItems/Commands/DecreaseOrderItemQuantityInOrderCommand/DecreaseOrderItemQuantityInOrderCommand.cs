using MediatR;

namespace Ordering.Application.OrderItems.Commands.DecreaseOrderItemQuantityInOrderCommand;

public class DecreaseOrderItemQuantityInOrderCommand : IRequest
{
    public required string OrderItemId { get; set; }

    public required int NewQuantity { get; set; }
}
