using MediatR;

namespace Ordering.Application.Orders.Commands.CancelOrder;

public class CancelOrderCommand : IRequest
{
    required public string OrderId { get; set; }
}
