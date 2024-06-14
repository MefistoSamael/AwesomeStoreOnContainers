namespace Catalog.Application.Common.Models;

public class ProductDTO
{
    required public string Id { get; set; }

    required public string Name { get; set; }

    required public string Description { get; set; }

    required public int Price { get; set; }

    required public int StockCount { get; set; }

    required public string ImageUri { get; set; }

    required public IEnumerable<CategoryDTO> ProductCatrgories { get; set; }
}
