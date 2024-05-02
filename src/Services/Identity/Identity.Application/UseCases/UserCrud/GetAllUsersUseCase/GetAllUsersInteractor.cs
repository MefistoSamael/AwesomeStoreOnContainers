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
    public class GetAllUsersInteractor : IRequestHandler<GetAllUsers, IEnumerable<ApplicationUser>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersInteractor(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ApplicationUser>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUsersAsync();
        }
    }
}
