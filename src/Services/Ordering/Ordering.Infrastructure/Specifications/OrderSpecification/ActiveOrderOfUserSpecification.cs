using Ordering.Domain.Entities;
using Ordering.Infrastructure.Specifications.Common;

namespace Ordering.Infrastructure.Specifications.OrderSpecification;

public class ActiveOrderOfUserSpecification : Specification<Order>
{
    public ActiveOrderOfUserSpecification(string buyerId)
        : base(order =>
        order.State == Domain.Enums.OrderState.Configuring &&
        order.BuyerId == buyerId)
    {
        AddInclude(order => order.OrderItems);
    }
}
