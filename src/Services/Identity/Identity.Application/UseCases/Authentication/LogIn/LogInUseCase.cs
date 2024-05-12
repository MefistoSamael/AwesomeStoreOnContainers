using MediatR;

namespace Identity.Application.UseCases.Authentication.LogIn;

public class LogInUseCase : IRequest<string>
{

    public string Password { get; set; }

    public string Email { get; set; }
}
