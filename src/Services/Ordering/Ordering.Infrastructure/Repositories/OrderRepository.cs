using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Abstractions;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Repositories;

public sealed class OrderRepository : IOrderRepository
{
    private readonly DbSet<Order> _orders;
    private readonly DbSet<OrderItem> _orderItems;
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
        _orders = context.Orders;
        _orderItems = context.OrderItems;
    }

    public async Task<string> CreateOrderAsync(Order order, CancellationToken cancellationToken)
    {
        order.Id = Guid.NewGuid().ToString();

        await _orders.AddAsync(order, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return order.Id;
    }

    public async Task<string> UpdateOrderAsync(Order order, CancellationToken cancellationToken)
    {
        _orders.Update(order);

        await _context.SaveChangesAsync(cancellationToken);

        return order.Id;
    }

    public async Task DeleteOrderAsync(Order order, CancellationToken cancellationToken)
    {
        _orders.Remove(order);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Order?> FirstOrDefaultAsync(Expression<Func<Order, bool>> filters, CancellationToken cancellationToken)
    {
        var order = await _orders.AsNoTracking()
                                 .Include(order => order.OrderItems)
                                 .FirstOrDefaultAsync(filters, cancellationToken);

        return order;
    }

    public async Task<IEnumerable<Order>> GetPaginatedOrdersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var orders = await _orders.AsNoTracking()
                                  .Include(order => order.OrderItems)
                                  .Skip((pageNumber - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync(cancellationToken);

        return orders;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync(Expression<Func<Order, bool>> filters, CancellationToken cancellationToken)
    {
        var orders = await _orders.AsNoTracking()
                                  .Include(order => order.OrderItems)
                                  .Where(filters)
                                  .ToListAsync(cancellationToken);

        return orders;
    }

    public async Task<Order> SingleAsync(Expression<Func<Order, bool>> filters, CancellationToken cancellationToken)
    {
        var order = await _orders.AsNoTracking()
                                 .Include(order => order.OrderItems)
                                 .SingleAsync(filters, cancellationToken);

        return order;
    }

    public async Task<Order?> SingleOrDefaultAsync(Expression<Func<Order, bool>> filters, CancellationToken cancellationToken)
    {
        var order = await _orders.AsNoTracking()
                                 .Include(order => order.OrderItems)
                                 .SingleOrDefaultAsync(filters, cancellationToken);

        return order;
    }
}
