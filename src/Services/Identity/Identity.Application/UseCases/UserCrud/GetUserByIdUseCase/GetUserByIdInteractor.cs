using AutoMapper;
using Identity.Application.Models;
using Identity.Domain.Abstractions.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.UserCrud.GetUserByIdUseCase
{
    public class GetUserByIdInteractor : IRequestHandler<GetUserById, UserDTO?>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdInteractor(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO?> Handle(GetUserById request, CancellationToken cancellationToken)
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
                return null;
            }
        }
    }
}
