using Identity.Domain.Abstractions.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.UserCrud.ChangeRoleUseCase
{
    public class ChangeRoleInteractor : IRequestHandler<ChangeRole, string>
    {
        private readonly IUserRepository _userRepository;

        public ChangeRoleInteractor(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(ChangeRole request, CancellationToken cancellationToken)
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
}
