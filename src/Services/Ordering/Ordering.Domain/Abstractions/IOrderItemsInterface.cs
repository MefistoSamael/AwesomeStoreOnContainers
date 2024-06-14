using System.Linq.Expressions;
using Ordering.Domain.Entities;

namespace Ordering.Domain.Abstractions;
public interface IOrderItemRepository
{
    Task<string> AddOrderItemAsync(OrderItem orderItem, CancellationToken cancellationToken);

    Task<string> UpdateOrderItemAsync(OrderItem orderItem, CancellationToken cancellationToken);

    Task DeleteOrderItemAsync(OrderItem orderItem, CancellationToken cancellationToken);

    Task<OrderItem?> FirstOrDefaultAsync(Expression<Func<OrderItem, bool>> filters, CancellationToken cancellationToken);

    Task<IEnumerable<OrderItem>> GetOrderItemsAsync(Expression<Func<OrderItem, bool>>? filters, CancellationToken cancellationToken);
}
