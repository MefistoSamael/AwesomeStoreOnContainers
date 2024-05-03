using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.RoleCrud.GetRoleByIdUseCase
{
    public class GetRoleByIdInteractor : IRequestHandler<GetRoleById, ApplicationRole?>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRoleByIdInteractor(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ApplicationRole?> Handle(GetRoleById request, CancellationToken cancellationToken)
        {
            return await _roleRepository.GetRoleAsync(request.RoleId);
        }
    }
}
