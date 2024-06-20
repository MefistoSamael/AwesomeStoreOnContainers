using MediatR;
using Ordering.Application.OrderItems.Queries.GetOrderItemsFromOrderQuery;
using Ordering.Domain.Repositories;

namespace Ordering.Application.OrderItems.Commands.RemoveOrderItemFromOrderCommand;

public class RemoveOrderItemFromOrderCommandHandler : IRequestHandler<RemoveOrderItemFromOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;

    public RemoveOrderItemFromOrderCommandHandler(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
    {
        _orderRepository = orderRepository;
        _orderItemRepository = orderItemRepository;
    }

    public async Task Handle(RemoveOrderItemFromOrderCommand request, CancellationToken cancellationToken)
    {
        var orderItem = await _orderItemRepository.SingleOrDefaultAsync(
            item => item.Id == request.OrderItemId,
            cancellationToken) ?? throw new NonExistentOrderException("can't find order item with specified id");

        var order = await _orderRepository.SingleOrDefaultAsync(
            order => order.Id == orderItem.OrderId,
            cancellationToken) ?? throw new NonExistentOrderException();

        if (order.State != Domain.Enums.OrderState.Configuring)
        {
            throw new InvalidOperationException("can't change order unless it is configuring");
        }

        await _orderItemRepository.RemoveAsync(orderItem, cancellationToken);
    }
}