using MediatR;

namespace Identity.Application.UseCases.Authentication.Register;

public class RegisterUseCase : IRequest<string>
{
    required public string Password { get; set; }

    required public string Email { get; set; }
}
