using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.UseCases.UserCrud.CreateUser;

public class CreateUserInteractor : IRequestHandler<CreateUserUseCase, string>
{
    private readonly IUserRepository _userRepository;
    PasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();
    public CreateUserInteractor(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Handle(CreateUserUseCase request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByEmailAsync(request.Email) is not null) 
            throw new NotImplementedException("existing email");

        ApplicationUser user = new ApplicationUser(request.Email, request.Password);
        user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

        var id = await _userRepository.CreateUserAsync(user);

        await _userRepository.AddToRoleAsync(user, request.Role);

        return id;
    }
}
