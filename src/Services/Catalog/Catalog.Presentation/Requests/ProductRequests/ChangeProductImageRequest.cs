namespace Catalog.Presentation.Requests.ProductRequests;

public class ChangeProductImageRequest
{
    required public IFormFile Image { get; set; }
}
