using AutoMapper;
using Identity.Application.Common.Models;
using Identity.Domain.Abstractions.Interfaces;
using MediatR;

namespace Identity.Application.UseCases.UserCrud.GetPaginatedUsers;

public class GetPaginatedUsersInteractor : IRequestHandler<GetPaginatedUsersUseCase, PaginatedResult<UserDTO>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetPaginatedUsersInteractor(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedResult<UserDTO>> Handle(GetPaginatedUsersUseCase request, CancellationToken cancellationToken)
    {
        var applicationUsers = await _userRepository.GetPaginatedUsersAsync(request.PageNumber, request.PageSize, cancellationToken);
        IEnumerable<UserDTO> users = _mapper.Map<List<UserDTO>>(applicationUsers);

        var itemsCount = await _userRepository.GetUsersCountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(itemsCount / (double)request.PageSize);

        foreach (var user in users)
        {
            user.RoleName = await _userRepository.GetUserRoleAsync(user.Id);
        }

        return new PaginatedResult<UserDTO>
        {
            Collection = users,

            PageSize = request.PageSize,
            CurrentPage = request.PageNumber,

            TotalItemCount = itemsCount,
            TotalPageCount = totalPages,
        };
    }
}
