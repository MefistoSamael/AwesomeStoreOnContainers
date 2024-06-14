using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Abstractions;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Repositories;

public sealed class OrderItemRepository : IOrderItemRepository
{
    private readonly DbSet<OrderItem> _orderItems;
    private readonly ApplicationDbContext _context;

    public OrderItemRepository(ApplicationDbContext context)
    {
        _context = context;
        _orderItems = context.OrderItems;
    }

    public async Task<string> AddOrderItemAsync(OrderItem orderItem, CancellationToken cancellationToken)
    {
        orderItem.Id = Guid.NewGuid().ToString();

        await _orderItems.AddAsync(orderItem, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return orderItem.Id;
    }

    public async Task<string> UpdateOrderItemAsync(OrderItem orderItem, CancellationToken cancellationToken)
    {
        _orderItems.Update(orderItem);

        await _context.SaveChangesAsync(cancellationToken);

        return orderItem.Id;
    }

    public async Task DeleteOrderItemAsync(OrderItem orderItem, CancellationToken cancellationToken)
    {
        _orderItems.Remove(orderItem);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<OrderItem?> FirstOrDefaultAsync(Expression<Func<OrderItem, bool>> filters, CancellationToken cancellationToken)
    {
        return await _orderItems.AsNoTracking().FirstOrDefaultAsync(filters, cancellationToken);
    }

    public async Task<IEnumerable<OrderItem>> GetOrderItemsAsync(Expression<Func<OrderItem, bool>>? filters, CancellationToken cancellationToken)
    {
        if (filters is null)
        {
            return await _orderItems.AsNoTracking().ToListAsync(cancellationToken);
        }

        return await _orderItems.AsNoTracking().Where(filters).ToListAsync(cancellationToken);
    }
}
