namespace Catalog.Application.Common.Options;

public class CategoryPaginationOptions
{
    required public int PageNumber { get; set; }

    required public int PageSize { get; set; }
}
