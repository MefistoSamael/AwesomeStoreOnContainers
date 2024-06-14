using MediatR;

namespace Identity.Application.UseCases.UserCrud.CreateUser;

public class CreateUserUseCase : IRequest<string>
{
    public string Password { get; set; }

    public string Email { get; set; }

    public string Role { get; set; }
}
