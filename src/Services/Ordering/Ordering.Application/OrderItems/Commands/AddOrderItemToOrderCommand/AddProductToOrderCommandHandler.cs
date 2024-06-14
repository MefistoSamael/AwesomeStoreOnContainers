using AutoMapper;
using MediatR;
using Ordering.Application.Common.Exceptions;
using Ordering.Application.OrderItems.Queries.GetOrderItemsFromOrderQuery;
using Ordering.Application.Services;
using Ordering.Domain.Abstractions;
using Ordering.Domain.Entities;

namespace Ordering.Application.OrderItems.Commands.AddOrderItemToOrderCommand;

public class AddProductToOrderCommandHandler : IRequestHandler<AddProductToOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly IProductService _productService;

    public AddProductToOrderCommandHandler(IOrderRepository orderRepository, IProductService productService, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _productService = productService;
        _mapper = mapper;
    }

    public async Task Handle(AddProductToOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.SingleOrDefaultAsync(
            order => order.Id == request.OrderId,
            cancellationToken) ?? throw new NonExistentOrderException();

        if (order.OrderItems.SingleOrDefault(item => item.ProductId == request.ProductId) is not null)
        {
            throw new ExistingOrderItemException();
        }

        var product = await _productService.GetProductByIdAsync(request.ProductId);

        if (product is null)
        {
            throw new NonExistentProductException();
        }

        var orderItem = _mapper.Map<OrderItem>(product);

        // TODO:
        // создание orderItem в репозитории?
        order.OrderItems.Add(orderItem);

        await _orderRepository.UpdateOrderAsync(order, cancellationToken);
    }
}
