using Catalog.Application.Common.Options;
using Microsoft.Extensions.Options;

namespace Catalog.Presentation.Common.OptionsSetup;

public class CategoryPaginationOptionsSetup : IConfigureOptions<CategoryPaginationOptions>
{
    private readonly IConfiguration _configuration;

    public CategoryPaginationOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(CategoryPaginationOptions options)
    {
        options.PageNumber = Convert.ToInt32(_configuration["CategoryPaginationOptions:MaxPageNumber"]);
        options.PageSize = Convert.ToInt32(_configuration["CategoryPaginationOptions:MaxPageSize"]);
    }
}