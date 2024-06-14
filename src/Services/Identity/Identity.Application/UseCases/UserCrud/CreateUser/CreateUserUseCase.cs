using MediatR;

namespace Identity.Application.UseCases.UserCrud.CreateUser;

public class CreateUserUseCase : IRequest<string>
{
    required public string Password { get; set; }

    required public string Email { get; set; }

    required public string Role { get; set; }
}
