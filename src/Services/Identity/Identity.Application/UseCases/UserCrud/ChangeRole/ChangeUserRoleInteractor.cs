using Identity.Domain.Abstractions.Interfaces;
using MediatR;

namespace Identity.Application.UseCases.UserCrud.ChangeRole;

public class ChangeUserRoleInteractor : IRequestHandler<ChangeUserRoleUseCase, string>
{
    private readonly IUserRepository _userRepository;

    public ChangeUserRoleInteractor(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Handle(ChangeUserRoleUseCase request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId);

        if (user is null) 
        {
            throw new KeyNotFoundException("there are no user with such id");
        }

        var oldRole = await _userRepository.GetUserRoleAsync(request.UserId);

        // TODO: add aditional checks on success of this operation
        await _userRepository.AddToRoleAsync(user, request.RoleName);

        // user can have only one role
        await _userRepository.RemoveFromRoleAsync(user, oldRole);

        return user.Id;
    }
}
