using MediatR;

namespace Ordering.Application.Orders.Commands.ConfigureOrder;

public class ValidateOrderCommand : IRequest
{
    required public string OrderId { get; set; }
}
