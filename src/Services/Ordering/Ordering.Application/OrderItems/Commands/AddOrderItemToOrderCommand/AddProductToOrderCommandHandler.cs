using AutoMapper;
using MediatR;
using Ordering.Application.Common.Exceptions;
using Ordering.Application.OrderItems.Queries.GetOrderItemsFromOrderQuery;
using Ordering.Application.Services;
using Ordering.Domain.Entities;
using Ordering.Domain.Repositories;

namespace Ordering.Application.OrderItems.Commands.AddOrderItemToOrderCommand;

public class AddProductToOrderCommandHandler : IRequestHandler<AddProductToOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper _mapper;
    private readonly IProductService _productService;

    public AddProductToOrderCommandHandler(IOrderRepository orderRepository, IProductService productService, IMapper mapper, IOrderItemRepository orderItemRepository)
    {
        _orderRepository = orderRepository;
        _productService = productService;
        _mapper = mapper;
        _orderItemRepository = orderItemRepository;
    }

    public async Task Handle(AddProductToOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.SingleOrDefaultAsync(
            order => order.Id == request.OrderId,
            cancellationToken) ?? throw new NonExistentOrderException();

        if (order.State != Domain.Enums.OrderState.Configuring)
        {
            throw new InvalidOperationException("can't change order unless it is configuring");
        }

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
        orderItem.Quantity = request.Quantity;

        orderItem.Id = Guid.NewGuid().ToString();
        orderItem.OrderId = order.Id;

        await _orderItemRepository.CreateAsync(orderItem, cancellationToken);

        order.OrderItems.Add(orderItem);

        await _orderRepository.UpdateAsync(order, cancellationToken);
    }
}
