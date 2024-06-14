namespace Catalog.Domain.Entities;

public class Product
{
    required public string Id { get; set; }

    required public string Name { get; set; }

    required public string Description { get; set; }

    required public int Price { get; set; }

    public string? ImageFileName { get; set; }

    public string? ImageUri { get; set; }

    required public int StockCount { get; set; }

    public List<Category> Categories { get; set; } = new ();
}
