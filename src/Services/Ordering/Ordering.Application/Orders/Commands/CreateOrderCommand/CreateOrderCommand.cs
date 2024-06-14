using MediatR;

namespace Ordering.Application.Orders.Commands.CreateOrderCommand;

public class CreateOrderCommand : IRequest<string>
{
    public required string BuyerId { get; set; }
    
    public required string Description { get; set; }
}
