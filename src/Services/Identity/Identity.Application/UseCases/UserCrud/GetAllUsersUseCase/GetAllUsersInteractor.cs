using AutoMapper;
using Identity.Application.Models;
using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.UserCrud.GetAllUsersUseCase
{
    public class GetAllUsersInteractor : IRequestHandler<GetAllUsers, IEnumerable<UserDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersInteractor(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> Handle(GetAllUsers request, CancellationToken cancellationToken)
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
}
