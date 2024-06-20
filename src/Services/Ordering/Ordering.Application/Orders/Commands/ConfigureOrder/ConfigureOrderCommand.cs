using MediatR;

namespace Ordering.Application.Orders.Commands.ConfigureOrder;

public class ConfigureOrderCommand : IRequest
{
    required public string OrderId { get; set; }
}
