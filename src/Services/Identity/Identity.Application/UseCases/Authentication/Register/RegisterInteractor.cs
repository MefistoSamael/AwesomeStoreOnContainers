using Identity.Application.Common.Exceptions;
using Identity.Application.Common.Models;
using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.UseCases.Authentication.Register;

public class RegisterInteractor : IRequestHandler<RegisterUseCase, string>
{
    PasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();
    private readonly IUserRepository _userRepository;

    public RegisterInteractor(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<string> Handle(RegisterUseCase request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);

        if (user is not null)
        {
            throw new ExistingUserException("User with such email already exists");
        }


        user = new ApplicationUser(request.Email, request.Password);
        user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

        await _userRepository.CreateUserAsync(user);
        await _userRepository.AddToRoleAsync(user, "Buyer");

        return user.Id;
    }
}
