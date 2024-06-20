﻿using AutoMapper;
using Contracts.Events.OrderingEvents;
using MassTransit;
using MediatR;
using Ordering.Application.OrderItems.Queries.GetOrderItemsFromOrderQuery;
using Ordering.Domain.Enums;
using Ordering.Domain.Repositories;

namespace Ordering.Application.Orders.Commands.CancelOrder;

public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IMapper _mapper;

    public CancelOrderCommandHandler(IOrderRepository orderRepository, IPublishEndpoint publishEndpoint, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _publishEndpoint = publishEndpoint;
        _mapper = mapper;
    }

    public async Task Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.SingleOrDefaultAsync(
            order => order.Id == request.OrderId,
            cancellationToken) ?? throw new NonExistentOrderException();

        order.State = OrderState.Canceled;

        await _orderRepository.UpdateAsync(order, cancellationToken);

        // generate signalr message
        var @event = _mapper.Map<OrderCanceledEvent>(order);

        await _publishEndpoint.Publish(@event);
    }
}
