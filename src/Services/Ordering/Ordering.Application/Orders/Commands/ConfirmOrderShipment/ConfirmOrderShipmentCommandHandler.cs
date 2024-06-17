using MediatR;
using Ordering.Application.OrderItems.Queries.GetOrderItemsFromOrderQuery;
using Ordering.Domain.Repositories;

namespace Ordering.Application.Orders.Commands.ConfirmOrderShipment;

public class ConfirmOrderShipmentCommandHandler : IRequestHandler<ConfirmOrderShipmentCommand>
{
    private readonly IOrderRepository _orderRepository;
    //private readonly IPublishEndpoint _publishEndpoint;

    public ConfirmOrderShipmentCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(ConfirmOrderShipmentCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.SingleOrDefaultAsync(
            order => order.Id == request.OrderId,
            cancellationToken) ?? throw new NonExistentOrderException();

        if (order.State != Domain.Enums.OrderState.Confirmed)
        {
            throw new InvalidOperationException("Can't confirm shipment unless the order is in confirmed state");
        }

        order.State = Domain.Enums.OrderState.Shipped;

        await _orderRepository.UpdateAsync(order, cancellationToken);

        //await _publishEndpoint.Publish();
    }
}
