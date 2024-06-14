namespace Identity.Application.Common.Models;

public class PaginatedResult<T>
{
    required public IEnumerable<T> Collection { get; set; }

    required public int CurrentPage { get; set; }

    required public int TotalPageCount { get; set; }

    required public int TotalItemCount { get; set; }

    required public int PageSize { get; set; }
}
