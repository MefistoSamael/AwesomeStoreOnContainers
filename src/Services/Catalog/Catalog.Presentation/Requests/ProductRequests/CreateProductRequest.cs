namespace Catalog.Presentation.Requests.ProductRequests;

public class CreateProductRequest
{
    required public string Name { get; set; }

    required public string Description { get; set; }

    required public int Price { get; set; }

    required public IFormFile Image { get; set; }

    required public int StockCount { get; set; }

    required public IEnumerable<string> Categories { get; set; }
}