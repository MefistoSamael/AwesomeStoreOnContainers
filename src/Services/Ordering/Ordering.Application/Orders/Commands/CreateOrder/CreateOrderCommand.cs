using MediatR;

namespace Ordering.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<string>
{
    required public string BuyerId { get; set; }

    required public string Description { get; set; }
}
