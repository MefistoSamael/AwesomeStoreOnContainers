namespace Catalog.Application.Common.Options;

public class CategoryPaginationOptions
{
    public required int PageNumber { get; set; }
    
    public required int PageSize{ get; set; }
}
