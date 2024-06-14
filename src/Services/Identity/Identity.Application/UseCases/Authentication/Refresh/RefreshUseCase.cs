using Identity.Application.Common.Models;
using MediatR;

namespace Identity.Application.UseCases.Authentication.Refresh;

public class RefreshUseCase : IRequest<TokensResponse>
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
}

