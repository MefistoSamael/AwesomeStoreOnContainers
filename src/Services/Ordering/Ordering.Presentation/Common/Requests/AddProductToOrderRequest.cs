namespace Ordering.Presentation.Common.Requests;

public class AddProductToOrderRequest
{
    required public string OrderId { get; set; }

    required public string ProductId { get; set; }

    required public int Quantity { get; set; }
}