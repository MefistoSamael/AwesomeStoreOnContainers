namespace Catalog.Presentation.Requests.ProductRequests;

public class UpdateProductRequest
{
    required public string Name { get; set; }

    required public string Description { get; set; }

    public int Price { get; set; }
}