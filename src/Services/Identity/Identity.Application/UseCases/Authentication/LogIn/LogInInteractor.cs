using Identity.Application.Common.Exceptions;
using Identity.Application.Common.Models;
using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.UseCases.Authentication.LogIn;

public class LogInInteractor : IRequestHandler<LogInUseCase, TokensResponse>
{
    PasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    private readonly IRefreshTokenProvider _refreshTokenProvider;

    public LogInInteractor(IJwtProvider jwtProvider, IUserRepository userRepository, IRefreshTokenProvider refreshTokenProvider)
    {
        _jwtProvider = jwtProvider;
        _userRepository = userRepository;
        _refreshTokenProvider = refreshTokenProvider;
    }

    public async Task<TokensResponse> Handle(LogInUseCase request, CancellationToken cancellationToken)
    {
        ApplicationUser? user = await _userRepository.GetUserByEmailAsync(request.Email);

        if (user is null)
        {
            throw new MissMatchingUserCredentialsException("there are no user with such combination of username and password");
        }

        if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
        {
            throw new MissMatchingUserCredentialsException("there are no user with such combination of username and password");
        }

        var JwtToken = await _jwtProvider.GenerateJwt(user);

        var refreshTokenResult = _refreshTokenProvider.Genereate();

        user.RefreshToken = refreshTokenResult.Token;
        user.RefreshTokenExpiry = refreshTokenResult.Expiry;

        await _userRepository.UpdateUser(user);

        return new TokensResponse
        {
            JwtToken = JwtToken.Token,
            RefreshToken = refreshTokenResult.Token,
        };
    }
}
