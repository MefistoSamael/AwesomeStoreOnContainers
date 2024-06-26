using MediatR;
using Ordering.Application.OrderItems.Queries.GetOrderItemsFromOrderQuery;
using Ordering.Domain.Repositories;

namespace Ordering.Application.Orders.Commands.ConfigureOrder;

public class ConfigureOrderCommandHandler : IRequestHandler<ConfigureOrderCommand>
{
    private readonly IOrderRepository _orderRepository;

    public ConfigureOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(ConfigureOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetOrderById(
            request.OrderId,
            cancellationToken) ?? throw new NonExistentOrderException();

        if (order.State != Domain.Enums.OrderState.Configuring)
        {
            throw new InvalidOperationException("Can't confirm order unless the order is in configuring state");
        }

        order.State = Domain.Enums.OrderState.AwaitingValidation;

        await _orderRepository.UpdateAsync(order, cancellationToken);
    }
}
