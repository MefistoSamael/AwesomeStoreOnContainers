using Ordering.Domain.Entities;
using Ordering.Infrastructure.Specifications.Common;

namespace Ordering.Infrastructure.Specifications.OrderSpecification;

public class OrderByIdSpecification : GetByIdSpecification<Order>
{
    public OrderByIdSpecification(string id)
        : base(id)
    {
        AddInclude(order => order.OrderItems);
    }
}
