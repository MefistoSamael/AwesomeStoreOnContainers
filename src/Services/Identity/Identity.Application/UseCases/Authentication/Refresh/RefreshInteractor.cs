using Identity.Application.Common.Exceptions;
using Identity.Application.Common.Models;
using Identity.Application.Providers;
using Identity.Domain.Abstractions.Interfaces;
using MediatR;
using System.Security.Claims;

namespace Identity.Application.UseCases.Authentication.Refresh;

public class RefreshInteractor : IRequestHandler<RefreshUseCase, TokensResponse>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenProvider _refreshTokenProvider;

    public RefreshInteractor(IJwtProvider jwtProvider, IUserRepository userRepository, IRefreshTokenProvider refreshTokenProvider)
    {
        _jwtProvider = jwtProvider;
        _userRepository = userRepository;
        _refreshTokenProvider = refreshTokenProvider;
    }

    public async Task<TokensResponse> Handle(RefreshUseCase request, CancellationToken cancellationToken)
    {
        var principal = _jwtProvider.GetPrincipalFromExpiredToken(request.AccessToken);

        var email = principal?.FindFirstValue(ClaimTypes.Email);

        if (email is null)
        {
            throw new UnauthorizedException();
        }

        var user = await _userRepository.GetUserByEmailAsync(email);

        if (user is null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiry < DateTime.UtcNow)
        {
            throw new UnauthorizedException();
        }

        var jwtToken = await _jwtProvider.GenerateJwt(user);

        var refreshTokenResult = _refreshTokenProvider.Genereate();

        user.RefreshToken = refreshTokenResult.Token;
        user.RefreshTokenExpiry = refreshTokenResult.Expiry;

        await _userRepository.UpdateUser(user);

        return new TokensResponse
        {
            JwtToken = jwtToken.Token,
            RefreshToken = refreshTokenResult.Token,
        };
    }
}
