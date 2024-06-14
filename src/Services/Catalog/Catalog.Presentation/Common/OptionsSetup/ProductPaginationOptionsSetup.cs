using Catalog.Application.Common.Options;
using Microsoft.Extensions.Options;

namespace Catalog.Presentation.Common.OptionsSetup;

public class ProductPaginationOptionsSetup : IConfigureOptions<ProductPaginationOptions>
{
    private readonly IConfiguration _configuration;

    public ProductPaginationOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(ProductPaginationOptions options)
    {
        options.PageNumber = Convert.ToInt32(_configuration["CategoryPaginationOptions:MaxPageNumber"]);
        options.PageSize = Convert.ToInt32(_configuration["CategoryPaginationOptions:MaxPageSize"]);
    }
}