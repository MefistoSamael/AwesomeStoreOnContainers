using MediatR;
using Ordering.Application.Common.Models;

namespace Ordering.Application.OrderItems.Queries.GetOrderItemsFromOrderQuery;

public class GetOrderItemsFromOrderQuery : IRequest<IEnumerable<OrderItemDTO>>
{
    required public string OrderId { get; set; }
}
