using Identity.Application.Common.Exceptions;
using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.UseCases.UserCrud.CreateUser;

public class CreateUserInteractor : IRequestHandler<CreateUserUseCase, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly PasswordHasher<ApplicationUser> _passwordHasher = new ();

    public CreateUserInteractor(IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task<string> Handle(CreateUserUseCase request, CancellationToken cancellationToken)
    {
        if (await _roleRepository.GetRoleByNameAsync(request.Role) is null)
        {
            throw new UnexistingRoleException("There are no such role");
        }

        if (await _userRepository.GetUserByEmailAsync(request.Email) is not null)
        {
            throw new ExistingUserException("User with such email already exists");
        }

        var user = new ApplicationUser(request.Email, request.Password);
        user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

        var id = await _userRepository.CreateUserAsync(user);

        await _userRepository.AddToRoleAsync(user, request.Role);

        return id;
    }
}
