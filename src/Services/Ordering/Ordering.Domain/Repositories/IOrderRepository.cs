using Ordering.Domain.Abstractions;
using Ordering.Domain.Entities;
using System.Linq.Expressions;

namespace Ordering.Domain.Repositories;
public interface IOrderRepository : IGenericRepository<Order>
{
    public Task<IEnumerable<Order>> GetPaginatedOrderdsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

    public Task<IEnumerable<Order>> GetPaginatedOrderdsAsync(Expression<Func<Order, bool>> filters, int pageNumber, int pageSize, CancellationToken cancellationToken);
}
