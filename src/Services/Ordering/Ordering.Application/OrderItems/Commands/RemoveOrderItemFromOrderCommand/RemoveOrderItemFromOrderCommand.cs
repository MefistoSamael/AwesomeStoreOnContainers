using MediatR;

namespace Ordering.Application.OrderItems.Commands.RemoveOrderItemFromOrderCommand;

public class RemoveOrderItemFromOrderCommand : IRequest
{
    required public string OrderItemId { get; set; }
}
