using Ordering.Domain.Entities;
using Ordering.Infrastructure.Specifications.Common;

namespace Ordering.Infrastructure.Specifications.OrderSpecification;

public class PaginatedOrdersSpecification : GetPaginatedSpecification<Order>
{
    public PaginatedOrdersSpecification(int pageNumber, int pageSize)
        : base(pageNumber, pageSize)
    {
        AddInclude(order => order.OrderItems);
    }
}
