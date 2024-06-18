using Ordering.Domain.Entities;
using Ordering.Domain.Repositories;

namespace Ordering.Infrastructure.Repositories.EntityRepository;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}
