using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.UseCases.UserCrud.CreateUserUseCase
{
    public class CreateUserInteractor : IRequestHandler<CreateUser, string>
    {
        private readonly IUserRepository _userRepository;
        PasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();
        public CreateUserInteractor(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetUserByUserNameAsync(request.UserName) is not null)
                throw new NotImplementedException("existing username");

            if (await _userRepository.GetUserByEmailAsync(request.Email) is not null) 
                throw new NotImplementedException("existing email");

            ApplicationUser user = new ApplicationUser(request.Email, request.UserName, request.Password);
            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            return await _userRepository.CreateUserAsync(user, request.Role);
        }
    }
}
