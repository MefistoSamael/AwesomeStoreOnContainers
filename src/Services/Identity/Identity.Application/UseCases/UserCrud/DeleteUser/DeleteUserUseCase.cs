using MediatR;

namespace Identity.Application.UseCases.UserCrud.DeleteUser;

public class DeleteUserUseCase : IRequest
{
    required public string Id { get; set; }
}
