using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities;
using Ordering.Domain.Repositories;
using System.Linq.Expressions;

namespace Ordering.Infrastructure.Repositories.EntityRepository;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Order>> GetPaginatedOrderdsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var orders = await _dbSet.AsNoTracking()
                                  .Include(order => order.OrderItems)
                                  .Skip((pageNumber - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync(cancellationToken);

        return orders;
    }

    public async Task<IEnumerable<Order>> GetPaginatedOrderdsAsync(Expression<Func<Order, bool>> filters, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var orders = await _dbSet.AsNoTracking()
                                  .Include(order => order.OrderItems)
                                  .Skip((pageNumber - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync(cancellationToken);

        return orders;
    }
}
