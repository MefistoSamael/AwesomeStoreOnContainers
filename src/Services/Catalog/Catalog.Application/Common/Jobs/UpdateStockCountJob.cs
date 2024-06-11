using AutoMapper;
using Catalog.Application.Common.Options;
using Catalog.Domain.Abstractions;
using Contracts;
using MassTransit;
using Microsoft.Extensions.Options;

namespace Catalog.Application.Common.Jobs;

public class UpdateStockCountJob : IUpdateStockCountJob
{
    private readonly IProductRepostitory _productRepostitory;
    private readonly StockCountUpdationOptions _options;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IMapper _mapper;

    public UpdateStockCountJob(IOptions<StockCountUpdationOptions> options,
        IProductRepostitory productRepostitory,
        IPublishEndpoint publishEndpoint,
        IMapper mapper)
    {
        _options = options.Value;
        _productRepostitory = productRepostitory;
        _publishEndpoint = publishEndpoint;
        _mapper = mapper;
    }

    public async Task Execute()
    {
        var products = await _productRepostitory.GetAllProductsAsync(null);

        foreach (var product in products)
        {
            var stockCountChanged = _mapper.Map<StockCountChangedEvent>(product);
            stockCountChanged.NewStockCount = product.StockCount + _options.RestockAmount;

            await _productRepostitory.AddStockCount(product, _options.RestockAmount);

            await _publishEndpoint.Publish(stockCountChanged);
        }
    }
}
