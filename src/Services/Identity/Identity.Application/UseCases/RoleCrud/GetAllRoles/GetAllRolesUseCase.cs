using Identity.Application.Models;
using MediatR;

namespace Identity.Application.UseCases.RoleCrud.GetAllRoles;

public class GetAllRolesUseCase : IRequest<IEnumerable<RoleDTO>>
{

}
