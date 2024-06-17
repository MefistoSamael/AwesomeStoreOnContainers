namespace Ordering.Application.Common.Models;

public class ProductResponse
{
    required public string Id { get; set; }

    required public string Name { get; set; }

    required public string ImageUri { get; set; }

    required public int Price { get; set; }
}