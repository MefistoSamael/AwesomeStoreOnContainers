using Identity.Application.Common.Exceptions;
using Identity.Domain.Abstractions.Interfaces;
using MediatR;

namespace Identity.Application.UseCases.UserCrud.ChangeRole;

public class ChangeUserRoleInteractor : IRequestHandler<ChangeUserRoleUseCase, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public ChangeUserRoleInteractor(IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task<string> Handle(ChangeUserRoleUseCase request, CancellationToken cancellationToken)
    {
        if (await _roleRepository.GetRoleByNameAsync(request.RoleName) is null)
        {
            throw new UnexistingRoleException("There are no such role");
        }

        var user = await _userRepository.GetUserByIdAsync(request.UserId);
        if (user is null)
        {
            throw new KeyNotFoundException("There are no user with such id");
        }

        var oldRole = await _userRepository.GetUserRoleAsync(request.UserId);
        if (oldRole == request.RoleName)
        {
            return request.UserId;
        }

        // user can have only one role
        await _userRepository.RemoveFromRoleAsync(user, oldRole);
        await _userRepository.AddToRoleAsync(user, request.RoleName);

        return user.Id;
    }
}
