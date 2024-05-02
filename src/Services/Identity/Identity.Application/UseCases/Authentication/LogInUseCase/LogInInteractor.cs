using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.UseCases.Authentication.LogInUseCase
{
    public class LogInInteractor : IRequestHandler<LogIn, string>
    {
        PasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public LogInInteractor(IJwtProvider jwtProvider, IUserRepository userRepository)
        {
            _jwtProvider = jwtProvider;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(LogIn request, CancellationToken cancellationToken)
        {
            ApplicationUser? user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user is null)
                throw new NotImplementedException("user doesn't exist");

            if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
                throw new NotImplementedException("invalid password");

            string token = await _jwtProvider.Generate(user);

            return token;
        }
    }
}
