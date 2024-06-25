using AutoMapper;
using Contracts.Messages.CatalogMessages;
using MassTransit;
using Ordering.Domain.Repositories;

namespace Ordering.Application.Consumers.CatalogConsumers;

public class ProductChangedConsumer : IConsumer<ProductChangedMessage>
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper _mapper;

    public ProductChangedConsumer(IOrderItemRepository orderItemRepository, IMapper mapper)
    {
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<ProductChangedMessage> context)
    {
        var @event = context.Message;

        var orderItems = await _orderItemRepository.Where(
            orderItem => orderItem.ProductId == context.Message.ProductId, default);

        if (!orderItems.Any())
        {
            return;
        }

        var tasks = new List<Task>();

        foreach (var orderItem in orderItems)
        {
            if (orderItem.Price != @event.Price)
            {
                // signalr message generation
            }

            if (orderItem.Quantity != @event.StockCount)
            {
                // signalr message generation
            }

            var newOrderItem = _mapper.Map(@event, orderItem);

            tasks.Add(_orderItemRepository.UpdateAsync(newOrderItem, default));
        }

        await Task.WhenAll(tasks);
    }
}
