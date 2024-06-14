using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using Ordering.Domain.Abstractions;
using Ordering.Domain.Entities;

namespace Ordering.Application.Orders.Commands.CreateOrderCommand;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, string>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Expression<Func<Order, bool>> userHasOrder = order =>
                                        order.BuyerId == request.BuyerId &&
                                        order.State == OrderState.Configuring;

        if (await _orderRepository.SingleOrDefaultAsync(userHasOrder, cancellationToken) is not null)
        {
            throw new InvalidOperationException("user alredy has configuring order");
        }

        var order = _mapper.Map<Order>(request);

        return await _orderRepository.CreateOrderAsync(order, cancellationToken);
    }
}
