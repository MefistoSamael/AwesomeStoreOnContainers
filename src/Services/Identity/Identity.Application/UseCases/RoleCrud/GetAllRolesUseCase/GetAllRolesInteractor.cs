using AutoMapper;
using Identity.Application.Models;
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
    public class GetAllRolesInteractor : IRequestHandler<GetAllRoles, IEnumerable<RoleDTO>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public GetAllRolesInteractor(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDTO>> Handle(GetAllRoles request, CancellationToken cancellationToken)
        {
            var applicationRoles = await _roleRepository.GetAllRolesAsync();
            IEnumerable<RoleDTO> roles = _mapper.Map<IEnumerable<RoleDTO>>(applicationRoles);

            return roles;
        }
    }
}
