namespace Identity.Application.Common.Models;

public class PaginatedResult<T>
{
    public required IEnumerable<T> Collection { get; set; }

    public required int CurrentPage { get; set; }

    public required int TotalPageCount { get; set; }

    public required int TotalItemCount { get; set; }

    public required int PageSize { get; set; }
}
