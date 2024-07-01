using MediatR;

namespace Identity.Application.UseCases.UserCrud.ChangeRole;

public class ChangeUserRoleUseCase : IRequest<string>
{
    required public string UserId { get; set; }

    required public string RoleName { get; set; }
}
