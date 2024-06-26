using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities;
using Ordering.Domain.Repositories;
using Ordering.Infrastructure.Specifications.Common;
using Ordering.Infrastructure.Specifications.OrderSpecification;

namespace Ordering.Infrastructure.Repositories.EntityRepository;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Order>> GetPaginatedOrderdsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var orders = await ApplySpecification(
            new PaginatedOrdersSpecification(pageNumber, pageSize))
                                  .ToListAsync(cancellationToken);

        return orders;
    }

    public async Task<IEnumerable<Order>> GetPaginatedOrderdsOfUserAsync(string userId, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var orders = await ApplySpecification(
            new PaginatedOrdersOfUserSpecification(pageNumber, pageSize, userId))
                                  .ToListAsync(cancellationToken);

        return orders;
    }

    public async Task<Order?> GetOrderById(string orderId, CancellationToken cancellationToken = default)
    {
        var order = await ApplySpecification(
            new OrderByIdSpecification(orderId)).SingleOrDefaultAsync();

        return order;
    }

    public async Task<Order?> GetUserActiveOrder(string buyerId, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(
            new ActiveOrderOfUserSpecification(buyerId)).SingleOrDefaultAsync();
    }
}
