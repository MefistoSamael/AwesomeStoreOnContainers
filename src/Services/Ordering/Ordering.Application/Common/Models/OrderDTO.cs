using Ordering.Domain.Entities;

namespace Ordering.Application.Common.Models;

public class OrderDTO
{
    public required string Id { get; set; }

    public required string BuyerId { get; set; }

    public required string Description { get; set; }

    public required List<OrderItemDTO>? OrderItems { get; set; }

    public required string State { get; set; }
}
