using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.RoleCrud.GetAllRolesUseCase
{
    public class GetAllRolesInteractor : IRequestHandler<GetAllRoles, IEnumerable<ApplicationRole>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetAllRolesInteractor(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<ApplicationRole>> Handle(GetAllRoles request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetAllRolesAsync();

            return roles;
        }
    }
}
