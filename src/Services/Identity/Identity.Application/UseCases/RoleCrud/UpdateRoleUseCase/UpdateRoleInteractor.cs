using Identity.Domain.Abstractions.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.RoleCrud.UpdateRoleUseCase
{
    public class UpdateRoleInteractor : IRequestHandler<UpdateRole, string>
    {
        private readonly IRoleRepository _roleRepository;

        public UpdateRoleInteractor(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<string> Handle(UpdateRole request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetRoleAsync(request.RoleId);
            
            //FOR DEVELOPMENT PURPOSES ONLY
            if (role is null)
            {
                throw new KeyNotFoundException("there are no role with such id");
            }

            role.Name = request.NewRoleName;
            string id = await _roleRepository.UpdateRoleAsync(role);

            return id;
        }
    }
}
