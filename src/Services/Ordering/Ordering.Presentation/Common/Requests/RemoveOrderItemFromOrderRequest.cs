namespace Ordering.Presentation.Common.Requests;

public class RemoveOrderItemFromOrderRequest
{
    required public string OrderItemId { get; set; }

    required public string OrderId { get; set; }
}
