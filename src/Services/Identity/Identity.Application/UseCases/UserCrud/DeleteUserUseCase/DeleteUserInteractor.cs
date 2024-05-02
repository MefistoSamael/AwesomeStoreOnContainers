using Identity.Domain.Abstractions.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.UserCrud.DeleteUserUseCase
{
    public class DeleteUserInteractor : IRequestHandler<DeleteUser>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserInteractor(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUserAsync(request.Id);
        }
    }
}
