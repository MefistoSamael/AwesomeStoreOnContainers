using Identity.Application.Common.Models;
using MediatR;

namespace Identity.Application.UseCases.Authentication.LogIn;

public class LogInUseCase : IRequest<TokensResponse>
{
    required public string Password { get; set; }

    required public string Email { get; set; }
}
