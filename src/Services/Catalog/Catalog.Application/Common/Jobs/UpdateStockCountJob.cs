using Catalog.Application.Common.Options;
using Catalog.Domain.Abstractions;
using Microsoft.Extensions.Options;

namespace Catalog.Application.Common.Jobs;

public class UpdateStockCountJob : IUpdateStockCountJob
{
    private readonly IProductRepostitory _productRepostitory;
    private readonly StockCountUpdationOptions _options;


    public UpdateStockCountJob(IOptions<StockCountUpdationOptions> options, IProductRepostitory productRepostitory)
    {
        _options = options.Value;
        _productRepostitory = productRepostitory;
    }

    public async Task Execute()
    {
        var products = await _productRepostitory.GetAllProductsAsync(null);

        foreach (var product in products)
        {
            await _productRepostitory.AddStockCount(product, _options.RestockAmount);
        }
    }
}
