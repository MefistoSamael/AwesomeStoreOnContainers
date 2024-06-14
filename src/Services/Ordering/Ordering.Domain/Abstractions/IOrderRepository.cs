using System.Linq.Expressions;
using Ordering.Domain.Entities;

namespace Ordering.Domain.Abstractions;
public interface IOrderRepository
{
    public Task<string> CreateOrderAsync(Order order, CancellationToken cancellationToken);

    public Task<string> UpdateOrderAsync(Order order, CancellationToken cancellationToken);

    public Task DeleteOrderAsync(Order order, CancellationToken cancellationToken);

    public Task<Order?> FirstOrDefaultAsync(Expression<Func<Order, bool>> filters, CancellationToken cancellationToken);

    public Task<Order> SingleAsync(Expression<Func<Order, bool>> filters, CancellationToken cancellationToken);

    public Task<Order?> SingleOrDefaultAsync(Expression<Func<Order, bool>> filters, CancellationToken cancellationToken);

    public Task<IEnumerable<Order>> GetPaginatedOrdersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

    public Task<IEnumerable<Order>> GetOrdersAsync(Expression<Func<Order, bool>> filters, CancellationToken cancellationToken);
}
