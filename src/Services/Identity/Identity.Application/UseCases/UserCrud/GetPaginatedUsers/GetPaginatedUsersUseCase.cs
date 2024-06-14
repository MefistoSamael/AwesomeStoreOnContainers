using Identity.Application.Common.Models;
using MediatR;

namespace Identity.Application.UseCases.UserCrud.GetPaginatedUsers;

public class GetPaginatedUsersUseCase : IRequest<PaginatedResult<UserDTO>>
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }
}
