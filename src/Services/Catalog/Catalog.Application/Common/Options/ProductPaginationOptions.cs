namespace Catalog.Application.Common.Options;

public class ProductPaginationOptions
{
    required public int PageNumber { get; set; }

    required public int PageSize { get; set; }
}
