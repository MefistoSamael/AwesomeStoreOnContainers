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

        public async Task Handle(DeleteRole request, CancellationToken cancellationToken)
        {
            if (await _roleRepository.GetRoleAsync(request.RoleId) is null) 
            {
                return;
            } 
            
            if (await _roleRepository.HasUsers(request.RoleId))
            {
                throw new InvalidOperationException("Role can't be deleted, while there are users assigned to is ");
            }
            else
            {
                await _roleRepository.DeleteRoleAsync(request.RoleId);
            }
        }
    }
}
