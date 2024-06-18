using MediatR;

namespace Ordering.Application.OrderItems.Commands.UpdateOrderItemQuantityCommand;

public class UpdateOrderItemQuantityCommand : IRequest
{
    required public string OrderItemId { get; set; }

    required public int NewQuantity { get; set; }
}
