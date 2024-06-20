using AutoMapper;
using Identity.Application.Common.Exceptions;
using Identity.Application.Common.Models;
using Identity.Domain.Abstractions.Interfaces;
using MediatR;

namespace Identity.Application.UseCases.UserCrud.GetUserById;

public class GetUserByIdInteractor : IRequestHandler<GetUserByIdUseCase, UserDTO?>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserByIdInteractor(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDTO?> Handle(GetUserByIdUseCase request, CancellationToken cancellationToken)
    {
        var applicationUser = await _userRepository.GetUserByIdAsync(request.UserId);
        if (applicationUser is not null)
        {
            var user = _mapper.Map<UserDTO>(applicationUser);
            user.RoleName = await _userRepository.GetUserRoleAsync(request.UserId);

            return user;
        }
        else
        {
            throw new NonExistentUserException(UserNotFoundMessage);
        }
    }
}
