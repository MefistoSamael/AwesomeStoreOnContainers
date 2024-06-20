using MediatR;

namespace Ordering.Application.OrderItems.Commands.AddOrderItemToOrderCommand;

public class AddProductToOrderCommand : IRequest
{
    required public string ProductId { get; set; }

    required public int Quantity { get; set; }

    required public string OrderId { get; set; }
}
