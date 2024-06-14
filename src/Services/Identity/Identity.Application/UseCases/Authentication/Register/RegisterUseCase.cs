using MediatR;

namespace Identity.Application.UseCases.Authentication.Register;

public class RegisterUseCase : IRequest<string>
{
    public string Password { get; set; }

    public string Email { get; set; }
}
