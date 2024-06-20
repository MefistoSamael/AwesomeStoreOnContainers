using Contracts.DTO;

namespace Contracts.Events.OrderingEvents;

// increate stock amount of product
public class OrderCanceledEvent : Event
{
    required public List<OrderProductDTO> OrderItems { get; set; }
}
