namespace Catalog.Presentation.Requests.ProductRequests;

public class CreateProductRequest
{
    public required string Name { get; set; }

    public required string Description { get; set; }

    public required int Price { get; set; }

    public required IFormFile Image { get; set; }

    public required int StockCount { get; set; }

    public required IEnumerable<string> Categories { get; set; }
}