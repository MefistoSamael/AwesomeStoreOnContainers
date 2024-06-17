using Ordering.Domain.Enums;

namespace Ordering.Presentation.Common.Mapper.Orders;

public class ChangeOrderStateRequest
{
    required public OrderState State { get; set; }
}