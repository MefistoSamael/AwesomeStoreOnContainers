using Contracts.DTO;

namespace Contracts.Messages.OrderingMessages;

// increate stock amount of product
public class OrderCanceledMessage : Message
{
    required public List<OrderProductDTO> OrderItems { get; set; }
}
