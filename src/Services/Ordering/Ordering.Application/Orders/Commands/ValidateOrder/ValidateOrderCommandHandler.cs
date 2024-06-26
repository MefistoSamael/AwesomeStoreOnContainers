using MediatR;
using Ordering.Application.OrderItems.Queries.GetOrderItemsFromOrderQuery;
using Ordering.Application.Orders.Commands.ConfigureOrder;
using Ordering.Domain.Repositories;

namespace Ordering.Application.Orders.Commands.ValidateOrder;

public class ValidateOrderCommandHandler : IRequestHandler<ValidateOrderCommand>
{
    private readonly IOrderRepository _orderRepository;

    public ValidateOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(ValidateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetOrderById(
            request.OrderId,
            cancellationToken) ?? throw new NonExistentOrderException();

        if (order.State != Domain.Enums.OrderState.AwaitingValidation)
        {
            throw new InvalidOperationException("Can't validate order unless it is in awaiting validation state");
        }

        order.State = Domain.Enums.OrderState.Confirmed;

        await _orderRepository.UpdateAsync(order, cancellationToken);
    }
}
