using MediatR;

namespace Identity.Application.UseCases.UserCrud.DeleteUser;

public class DeleteUserUseCase : IRequest
{
    public string Id { get; set; }
}
