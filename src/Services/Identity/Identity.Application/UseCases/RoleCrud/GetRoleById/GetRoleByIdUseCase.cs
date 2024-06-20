using Identity.Domain.Entities;
using MediatR;

namespace Identity.Application.UseCases.RoleCrud.GetRoleById;

public class GetRoleByIdUseCase : IRequest<ApplicationRole?>
{
    required public string RoleId { get; set; }
}
