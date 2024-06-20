using MediatR;
using Ordering.Application.Common.Models;

namespace Ordering.Application.Orders.Queries.GetUsersOrders;

public class GetUsersOrderQuery : IRequest<PaginatedResult<OrderDTO>>
{
    required public string UserId { get; set; }

    required public int PageNumber { get; set; }

    required public int PageSize { get; set; }
}
