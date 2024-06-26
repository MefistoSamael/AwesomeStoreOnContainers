using MediatR;
using Ordering.Application.Common.Exceptions;
using Ordering.Application.OrderItems.Queries.GetOrderItemsFromOrderQuery;
using Ordering.Domain.Repositories;

namespace Ordering.Application.OrderItems.Commands.UpdateOrderItemQuantityCommand;

public class UpdateOrderItemQuantityCommandHandler : IRequestHandler<UpdateOrderItemQuantityCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;

    public UpdateOrderItemQuantityCommandHandler(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
    {
        _orderRepository = orderRepository;
        _orderItemRepository = orderItemRepository;
    }

    public async Task Handle(UpdateOrderItemQuantityCommand request, CancellationToken cancellationToken)
    {
        var orderItem = await _orderItemRepository.GetOrderItemById(
            request.OrderItemId,
            cancellationToken) ?? throw new NonExistentOrderItemException();

        var order = await _orderRepository.GetOrderById(
            orderItem.OrderId,
            cancellationToken) ?? throw new NonExistentOrderException();

        if (order.State != Domain.Enums.OrderState.Configuring)
        {
            throw new InvalidOperationException("Can't change order unless it is in configuring state");
        }

        orderItem.Quantity = request.NewQuantity;

        await _orderItemRepository.UpdateAsync(orderItem, cancellationToken);
    }
}