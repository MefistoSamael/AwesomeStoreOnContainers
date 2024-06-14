using Identity.Application.Common.Models;
using MediatR;

namespace Identity.Application.UseCases.Authentication.Refresh;

public class RefreshUseCase : IRequest<TokensResponse>
{
    required public string AccessToken { get; set; }

    required public string RefreshToken { get; set; }
}
