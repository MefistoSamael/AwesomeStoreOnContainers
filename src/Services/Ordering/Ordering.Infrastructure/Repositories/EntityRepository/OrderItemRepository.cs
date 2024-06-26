using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities;
using Ordering.Domain.Repositories;
using Ordering.Infrastructure.Specifications.OrderItemSpecification;
using Ordering.Infrastructure.Specifications.UserSpecification;

namespace Ordering.Infrastructure.Repositories.EntityRepository;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<OrderItem?> GetOrderItemById(string orderItemId, CancellationToken cancellationToken = default)
    {
        var orderItem = await ApplySpecification(new OrderItemByIdSpecification(orderItemId))
            .SingleOrDefaultAsync(cancellationToken);

        return orderItem;
    }
}
