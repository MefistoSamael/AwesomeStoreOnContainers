namespace Catalog.Presentation.Requests.ProductRequests;

public class UpdateProductRequest
{
    public required string Name {  get; set; }

    public required string Description { get; set; }

    public int Price { get; set; }
}