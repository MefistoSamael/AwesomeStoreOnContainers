namespace Ordering.Application.Common.Models;

public class OrderItemDTO
{
    required public string Id { get; set; }

    required public string ProductName { get; set; }

    required public string ImageUri { get; set; }

    required public int Price { get; set; }

    required public int Quantity { get; set; }
}
