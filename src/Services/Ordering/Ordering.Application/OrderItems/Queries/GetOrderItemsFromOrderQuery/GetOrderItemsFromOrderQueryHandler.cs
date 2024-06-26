using AutoMapper;
using MediatR;
using Ordering.Application.Common.Models;
using Ordering.Domain.Repositories;

namespace Ordering.Application.OrderItems.Queries.GetOrderItemsFromOrderQuery;

public class GetOrderItemsFromOrderQueryHandler : IRequestHandler<GetOrderItemsFromOrderQuery, IEnumerable<OrderItemDTO>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderItemsFromOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderItemDTO>> Handle(GetOrderItemsFromOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetOrderById(
            request.OrderId,
            cancellationToken) ?? throw new NonExistentOrderException();

        return _mapper.Map<IEnumerable<OrderItemDTO>>(order.OrderItems);
    }
}
