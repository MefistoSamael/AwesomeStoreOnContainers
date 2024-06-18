namespace Ordering.Presentation.Common.Requests;

public class UpdateOrderItemQuantityRequest
{
    required public int NewQuantity { get; set; }
}