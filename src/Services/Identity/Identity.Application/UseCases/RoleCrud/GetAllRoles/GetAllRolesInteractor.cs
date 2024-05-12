using AutoMapper;
using Identity.Application.Models;
using Identity.Domain.Abstractions.Interfaces;
using MediatR;

namespace Identity.Application.UseCases.RoleCrud.GetAllRoles;

public class GetAllRolesInteractor : IRequestHandler<GetAllRolesUseCase, IEnumerable<RoleDTO>>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public GetAllRolesInteractor(IRoleRepository roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RoleDTO>> Handle(GetAllRolesUseCase request, CancellationToken cancellationToken)
    {
        var applicationRoles = await _roleRepository.GetAllRolesAsync();
        IEnumerable<RoleDTO> roles = _mapper.Map<IEnumerable<RoleDTO>>(applicationRoles);

        return roles;
    }
}
