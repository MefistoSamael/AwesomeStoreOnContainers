using Contracts.Events.IdentityEvents;
using Identity.Application.Common.Exceptions;
using Identity.Domain.Abstractions.Interfaces;
using MassTransit;
using MediatR;

namespace Identity.Application.UseCases.UserCrud.DeleteUser;

public class DeleteUserInteractor : IRequestHandler<DeleteUserUseCase>
{
    private readonly IUserRepository _userRepository;
    private readonly IPublishEndpoint _publishEndpoint;

    public DeleteUserInteractor(IUserRepository userRepository, IPublishEndpoint publishEndpoint)
    {
        _userRepository = userRepository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Handle(DeleteUserUseCase request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.Id);
        if (user is null)
        {
            throw new UserNotFoundException($"User with {request.Id} id wasn't found");
        }

        await _userRepository.DeleteUserAsync(request.Id);

        await _publishEndpoint.Publish(new BuyerDeletedEvent { BuyerId = request.Id });
    }
}
