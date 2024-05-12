using MediatR;

namespace Identity.Application.UseCases.UserCrud.ChangeRole;

public class ChangeUserRoleUseCase : IRequest<string>
{
    public string UserId { get; set; }

    public string RoleName { get; set; }
}
