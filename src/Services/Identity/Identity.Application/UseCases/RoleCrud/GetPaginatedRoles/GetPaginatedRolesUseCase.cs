using Identity.Application.Common.Models;
using MediatR;

namespace Identity.Application.UseCases.RoleCrud.GetPaginatedRoles;

public class GetPaginatedRolesUseCase : IRequest<PaginatedResult<RoleDTO>>
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }
}
