using Contracts.DTO;

namespace Contracts.Messages.OrderingMessages;

// reduce stock count of product
public class OrderConfiguredMessage : Message
{
    required public List<OrderProductDTO> OrderItems { get; set; }
}
