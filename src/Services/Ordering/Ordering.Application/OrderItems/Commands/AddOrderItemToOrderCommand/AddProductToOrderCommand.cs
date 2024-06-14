using MediatR;

namespace Ordering.Application.OrderItems.Commands.AddOrderItemToOrderCommand;

public class AddProductToOrderCommand : IRequest
{
    public required string ProductId { get; set; }

    public required int Quantity { get; set; }

    public required string OrderId { get; set; }
}
