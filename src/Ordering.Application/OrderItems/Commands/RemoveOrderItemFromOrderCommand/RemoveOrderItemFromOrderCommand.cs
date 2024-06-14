using MediatR;

namespace Ordering.Application.OrderItems.Commands.RemoveOrderItemFromOrderCommand;

public class RemoveOrderItemFromOrderCommand : IRequest
{
    public required string OrderItemId { get; set; }
}
