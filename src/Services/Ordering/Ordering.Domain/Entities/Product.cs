namespace Ordering.Domain.Entities;

public class Product
{
    required public string Id { get; set; }

    required public string Name { get; set; }

    required public string ImageUri { get; set; }

    required public int Price { get; set; }
}