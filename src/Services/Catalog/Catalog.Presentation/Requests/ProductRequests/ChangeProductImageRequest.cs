namespace Catalog.Presentation.Requests.ProductRequests;

public class ChangeProductImageRequest
{
    public required IFormFile Image { get; set; }
}

