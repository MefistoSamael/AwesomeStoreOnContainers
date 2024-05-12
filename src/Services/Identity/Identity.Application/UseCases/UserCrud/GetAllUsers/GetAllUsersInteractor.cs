using AutoMapper;
using Identity.Application.Models;
using Identity.Domain.Abstractions.Interfaces;
using MediatR;

namespace Identity.Application.UseCases.UserCrud.GetAllUsers;

public class GetAllUsersInteractor : IRequestHandler<GetAllUsersUseCase, IEnumerable<UserDTO>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUsersInteractor(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDTO>> Handle(GetAllUsersUseCase request, CancellationToken cancellationToken)
    {
        var applicationUsers = await _userRepository.GetAllUsersAsync();
        IEnumerable<UserDTO> users = _mapper.Map<List<UserDTO>>(applicationUsers);

        foreach (var user in users) 
        {
            user.RoleName = await _userRepository.GetUserRoleAsync(user.Id);
        }
        
        return users;
    }
}
