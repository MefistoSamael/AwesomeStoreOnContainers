using Identity.Domain.Abstractions.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.RoleCrud.DeleteRoleUseCase
{
    public class DeleteRoleInteractor : IRequestHandler<DeleteRole>
    {
        private readonly IRoleRepository _roleRepository;

        public DeleteRoleInteractor(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Task Handle(DeleteRole request, CancellationToken cancellationToken)
        {
            return _roleRepository.DeleteRoleAsync(request.RoleId);
        }
    }
}
