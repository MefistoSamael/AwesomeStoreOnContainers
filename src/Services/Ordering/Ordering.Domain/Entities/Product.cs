namespace Ordering.Domain.Entities;

public class Product
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public required string ImageUri { get; set; }

    public required int Price { get; set; }
}