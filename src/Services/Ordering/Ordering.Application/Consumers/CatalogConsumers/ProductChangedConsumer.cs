using AutoMapper;
using Contracts.Events.CatalogEvents;
using MassTransit;
using Ordering.Domain.Repositories;

namespace Ordering.Application.Consumers.CatalogConsumers;

public class ProductChangedConsumer : IConsumer<ProductChangedEvent>
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper _mapper;

    public ProductChangedConsumer(IOrderItemRepository orderItemRepository, IMapper mapper)
    {
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<ProductChangedEvent> context)
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
            var isUpdated = false;

            if (@event.NewProductName is not null)
            {
                orderItem.ProductName = @event.NewProductName;
                isUpdated = true;
            }

            if (@event.NewPrice is not null)
            {
                orderItem.Price = (int)@event.NewPrice;
                isUpdated = true;

                // signalr message generation
            }

            if (@event.NewImageUri is not null)
            {
                orderItem.ImageUri = @event.NewImageUri;
                isUpdated = true;
            }

            if (@event.NewStockCount is not null)
            {
                orderItem.Quantity = (int)@event.NewStockCount;
                isUpdated = true;

                // signalr message generation
            }

            if (isUpdated)
            {
                tasks.Add(_orderItemRepository.UpdateAsync(orderItem, default));
            }
        }

        await Task.WhenAll(tasks);
    }
}
