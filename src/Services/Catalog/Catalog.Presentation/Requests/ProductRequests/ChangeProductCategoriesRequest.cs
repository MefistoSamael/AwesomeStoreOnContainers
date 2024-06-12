namespace Catalog.Presentation.Requests.ProductRequests;

public class ChangeProductCategoriesRequest
{
    public required IEnumerable<string> Categories { get; set; }
}

