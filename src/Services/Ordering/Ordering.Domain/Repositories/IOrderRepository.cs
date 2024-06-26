using System.Linq.Expressions;
using System.Threading;
using Ordering.Domain.Abstractions;
using Ordering.Domain.Entities;

namespace Ordering.Domain.Repositories;
public interface IOrderRepository : IGenericRepository<Order>
{
    public Task<IEnumerable<Order>> GetPaginatedOrderdsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);

    public Task<IEnumerable<Order>> GetPaginatedOrderdsOfUserAsync(string userId, int pageNumber, int pageSize, CancellationToken cancellationToken = default);

    public Task<Order?> GetOrderById(string orderId, CancellationToken cancellationToken = default);

    public Task<Order?> GetUserActiveOrder(string buyerId, CancellationToken cancellationToken = default);
}
