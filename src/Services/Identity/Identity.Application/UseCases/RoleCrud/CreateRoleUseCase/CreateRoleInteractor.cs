using Identity.Domain.Abstractions.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.RoleCrud.CreateRoleUseCase
{
    public class CreateRoleInteractor : IRequestHandler<CreateRole, string>
    {
        private readonly IRoleRepository _roleRepository;

        public CreateRoleInteractor(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<string> Handle(CreateRole request, CancellationToken cancellationToken)
        {
            return await _roleRepository.CreateRoleAsync(new Domain.Entities.ApplicationRole(request.Name));
        }
    }
}
