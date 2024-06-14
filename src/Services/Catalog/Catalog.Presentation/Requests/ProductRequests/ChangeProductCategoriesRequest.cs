namespace Catalog.Presentation.Requests.ProductRequests;

public class ChangeProductCategoriesRequest
{
    required public IEnumerable<string> Categories { get; set; }
}
