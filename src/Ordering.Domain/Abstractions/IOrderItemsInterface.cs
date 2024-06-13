using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Abstractions;
public interface IOrderItemRepository
{
    Task<string> AddOrderItemAsync(OrderItem orderItem, CancellationToken cancellationToken);

    Task<string> UpdateOrderItemAsync(OrderItem orderItem, CancellationToken cancellationToken);

    Task DeleteOrderItemAsync(OrderItem orderItem, CancellationToken cancellationToken);


    Task<OrderItem?> FirstOrDefaultAsync(Expression<Func<OrderItem, bool>> filters, CancellationToken cancellationToken);

    Task<IEnumerable<OrderItem>> GetOrderItemsAsync(Expression<Func<OrderItem, bool>>? filters, CancellationToken cancellationToken);
}
