using Catalog.Application.Common.Options;
using Microsoft.Extensions.Options;

namespace Catalog.Presentation.Common.OptionsSetup;

public class StockCountUpdationOptionsSetup : IConfigureOptions<StockCountUpdationOptions>
{
    private readonly IConfiguration _configuration;

    public StockCountUpdationOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(StockCountUpdationOptions options)
    {
        options.RestockAmount = Convert.ToInt32(_configuration["StockCountUpdationOptions:RestockAmount"]);
    }
}