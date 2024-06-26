using Ordering.Domain.Entities;
using Ordering.Infrastructure.Specifications.Common;

namespace Ordering.Infrastructure.Specifications.OrderItemSpecification;

public class OrderItemByIdSpecification : GetByIdSpecification<OrderItem>
{
    public OrderItemByIdSpecification(string id)
        : base(id)
    {
    }
}
