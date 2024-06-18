using System.Linq.Expressions;
using Ordering.Domain.Abstractions;
using Ordering.Domain.Entities;

namespace Ordering.Domain.Repositories;
public interface IOrderRepository : IGenericRepository<Order>
{
    public Task<IEnumerable<Order>> GetPaginatedOrderdsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

    public Task<IEnumerable<Order>> GetPaginatedOrderdsAsync(Expression<Func<Order, bool>> filters, int pageNumber, int pageSize, CancellationToken cancellationToken);
}
