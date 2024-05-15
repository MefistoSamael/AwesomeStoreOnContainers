using Identity.Application.Common.Models;
using MediatR;

namespace Identity.Application.UseCases.Authentication.LogIn;

public class LogInUseCase : IRequest<TokensResponse>
{

    public string Password { get; set; }

    public string Email { get; set; }
}
