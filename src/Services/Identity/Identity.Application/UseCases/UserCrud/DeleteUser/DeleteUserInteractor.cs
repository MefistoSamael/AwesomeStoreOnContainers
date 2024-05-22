using Identity.Domain.Abstractions.Interfaces;
using MediatR;

namespace Identity.Application.UseCases.UserCrud.DeleteUser;

public class DeleteUserInteractor : IRequestHandler<DeleteUserUseCase>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserInteractor(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(DeleteUserUseCase request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByIdAsync(request.Id) is null)
        {
            return;
        }

        await _userRepository.DeleteUserAsync(request.Id);
    }
}
