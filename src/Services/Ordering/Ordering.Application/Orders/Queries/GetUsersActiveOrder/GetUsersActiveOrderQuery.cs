using MediatR;
using Ordering.Application.Common.Models;

namespace Ordering.Application.Orders.Queries.GetUsersActiveOrder;

public class GetUsersActiveOrderQuery : IRequest<OrderDTO>
{
    required public string UserId { get; set; }
}
