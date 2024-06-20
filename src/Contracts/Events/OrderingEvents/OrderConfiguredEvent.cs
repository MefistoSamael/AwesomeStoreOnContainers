using Contracts.DTO;

namespace Contracts.Events.OrderingEvents;

// reduce stock count of product
public class OrderConfiguredEvent : Event
{
    required public List<OrderProductDTO> OrderItems { get; set; }
}
