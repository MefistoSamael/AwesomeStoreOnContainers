using Ordering.Domain.Abstractions;
using Ordering.Domain.Entities;

namespace Ordering.Domain.Repositories;
public interface IOrderItemRepository : IGenericRepository<OrderItem>
{
    public Task<OrderItem?> GetOrderItemById(string orderItemId, CancellationToken cancellationToken = default);
}
