using AutoMapper;
using Contracts.Messages.OrderingMessages;
using MassTransit;
using MediatR;
using Ordering.Application.OrderItems.Queries.GetOrderItemsFromOrderQuery;
using Ordering.Domain.Entities;
using Ordering.Domain.Repositories;

namespace Ordering.Application.Orders.Commands.ConfigureOrder;

public class ConfigureOrderCommandHandler : IRequestHandler<ConfigureOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IMapper _mapper;

    public ConfigureOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _orderRepository = orderRepository;
        _publishEndpoint = publishEndpoint;
        _mapper = mapper;
    }

    public async Task Handle(ConfigureOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.SingleOrDefaultAsync(
            order => order.Id == request.OrderId,
            cancellationToken) ?? throw new NonExistentOrderException();

        if (order.State != Domain.Enums.OrderState.Configuring)
        {
            throw new InvalidOperationException("Can't confirm order unless the order is in configuring state");
        }

        order.State = Domain.Enums.OrderState.AwaitingValidation;

        await _orderRepository.UpdateAsync(order, cancellationToken);

        var newOrder = new Order { BuyerId = order.BuyerId, Id = Guid.NewGuid().ToString(), };

        await _orderRepository.CreateAsync(newOrder, default);

        // generate signalr message
        var @event = _mapper.Map<OrderConfiguredMessage>(order);

        await _publishEndpoint.Publish(@event, default);
    }
}
