namespace Ordering.Domain.Entities;

public class OrderItem
{
    required public string Id { get; set; }

    required public string ProductName { get; set; }

    required public string ImageUri { get; set; }

    required public int Price { get; set; }

    required public int Quantity { get; set; }

    required public string ProductId { get; set; }

    required public string OrderId { get; set; }
}
