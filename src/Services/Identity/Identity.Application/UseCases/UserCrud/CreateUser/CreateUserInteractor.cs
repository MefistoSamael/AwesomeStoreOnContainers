using Contracts.Messages.IdentityMessages;
using Identity.Application.Common.Exceptions;
using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Entities;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.UseCases.UserCrud.CreateUser;

public class CreateUserInteractor : IRequestHandler<CreateUserUseCase, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly PasswordHasher<ApplicationUser> _passwordHasher = new ();

    public CreateUserInteractor(IUserRepository userRepository, IRoleRepository roleRepository, IPublishEndpoint publishEndpoint)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<string> Handle(CreateUserUseCase request, CancellationToken cancellationToken)
    {
        if (await _roleRepository.GetRoleByNameAsync(request.Role) is null)
        {
            throw new NonExistentRoleException("There are no such role");
        }

        if (await _userRepository.GetUserByEmailAsync(request.Email) is not null)
        {
            throw new DuplicateUserException("User with such email already exists");
        }

        var user = new ApplicationUser(request.Email, request.Password);
        user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

        var id = await _userRepository.CreateUserAsync(user);

        await _userRepository.AddToRoleAsync(user, request.Role);

        if (request.Role.ToLower() == RoleConstants.Buyer.ToLower())
        {
            await _publishEndpoint.Publish(new BuyerCreatedMessage
            {
                BuyerId = id,
                BuyerEmail = user.Email!,
            });
        }

        return id;
    }
}
