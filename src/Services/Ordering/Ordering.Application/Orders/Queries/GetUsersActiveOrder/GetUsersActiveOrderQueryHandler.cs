using AutoMapper;
using MediatR;
using Ordering.Application.Common.Exceptions;
using Ordering.Application.Common.Models;
using Ordering.Domain.Repositories;

namespace Ordering.Application.Orders.Queries.GetUsersActiveOrder;

public class GetUsersActiveOrderQueryHandler : IRequestHandler<GetUsersActiveOrderQuery, OrderDTO>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersActiveOrderQueryHandler(IOrderRepository orderRepository, IUserRepository userRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<OrderDTO> Handle(GetUsersActiveOrderQuery request, CancellationToken cancellationToken)
    {
        if (await _userRepository.FirstOrDefaultAsync(user => user.Id == request.UserId, cancellationToken) is null)
        {
            throw new NonExistentUserException("user with specified id doesn't exist");
        }

        var domainOrder = await _orderRepository.GetUserActiveOrder(
            request.UserId,
            cancellationToken);

        var order = _mapper.Map<OrderDTO>(domainOrder);

        return order;
    }
}
