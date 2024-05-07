using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.UseCases.Authentication.RegisterUseCase
{
    public class RegisterInteractor : IRequestHandler<Register, string>
    {
        PasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public RegisterInteractor(IUserRepository userRepository, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }
        public async Task<string> Handle(Register request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            if (user is not null)
            {
                throw new NotImplementedException("existing user");
            }


            user = new ApplicationUser(request.Email, request.UserName, request.Password);
            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            await _userRepository.CreateUserAsync(user);
            await _userRepository.AddToRoleAsync(user, "Buyer");

            string token = await _jwtProvider.Generate(user);

            return token;
        }
    }
}
