namespace Ordering.Application.Common.Models;

public class OrderItemDTO
{
    public required string Id { get; set; }

    public required string ProductName { get; set; }

    public required string ImageUri { get; set; }

    public required int Price { get; set; }

    public required int Quantity { get; set; }
}
