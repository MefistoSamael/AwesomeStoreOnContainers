using Identity.Application.Common.Exceptions;
using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.UseCases.Authentication.LogIn;

public class LogInInteractor : IRequestHandler<LogInUseCase, string>
{
    PasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;

    public LogInInteractor(IJwtProvider jwtProvider, IUserRepository userRepository)
    {
        _jwtProvider = jwtProvider;
        _userRepository = userRepository;
    }

    public async Task<string> Handle(LogInUseCase request, CancellationToken cancellationToken)
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

        string token = await _jwtProvider.Generate(user);

        return token;
    }
}
