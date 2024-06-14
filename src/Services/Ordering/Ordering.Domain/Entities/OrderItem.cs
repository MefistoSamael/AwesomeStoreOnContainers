namespace Ordering.Domain.Entities;

public class OrderItem
{
    public required string Id { get; set; }

    public required string ProductName { get; set; }

    public required string ImageUri { get; set; }
    
    public required int Price { get; set; }

    public required int Quantity { get; set; }

    public required string ProductId { get; set; }

    public required string OrderId { get; set; }
}
