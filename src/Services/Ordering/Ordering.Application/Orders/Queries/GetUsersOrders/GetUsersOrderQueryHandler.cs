﻿using AutoMapper;
using MediatR;
using Ordering.Application.Common.Exceptions;
using Ordering.Application.Common.Models;
using Ordering.Domain.Repositories;

namespace Ordering.Application.Orders.Queries.GetUsersOrders;

public class GetUsersOrderQueryHandler : IRequestHandler<GetUsersOrderQuery, PaginatedResult<OrderDTO>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IBuyerRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper, IBuyerRepository userRepository)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<PaginatedResult<OrderDTO>> Handle(GetUsersOrderQuery request, CancellationToken cancellationToken)
    {
        var buyer = await _userRepository.FirstOrDefaultAsync(user => user.Id == request.UserId, cancellationToken);
        if (buyer is null)
        {
            throw new NonExistentUserException("user with specified id doesn't exist");
        }

        var domainOrders = await _orderRepository.GetPaginatedOrderdsAsync(
            order => order.BuyerId == request.UserId,
            request.PageNumber,
            request.PageSize,
            cancellationToken);

        var orders = _mapper.Map<IEnumerable<OrderDTO>>(domainOrders);

        foreach (var order in orders)
        {
            order.BuyerEmail = buyer.Email;
        }

        var count = await _orderRepository.GetCountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(count / (double)request.PageSize);

        return new PaginatedResult<OrderDTO>
        {
            Collection = orders,
            CurrentPage = request.PageNumber,
            PageSize = request.PageSize,
            TotalPageCount = totalPages,
            TotalItemCount = count,
        };
    }
}