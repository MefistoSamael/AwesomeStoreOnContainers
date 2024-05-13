using AutoMapper;
using Identity.Application.Common.Models;
using Identity.Domain.Abstractions.Interfaces;
using MediatR;

namespace Identity.Application.UseCases.RoleCrud.GetPaginatedRoles;

public class GetPaginatedRolesInteractor : IRequestHandler<GetPaginatedRolesUseCase, PaginatedResult<RoleDTO>>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public GetPaginatedRolesInteractor(IRoleRepository roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedResult<RoleDTO>> Handle(GetPaginatedRolesUseCase request, CancellationToken cancellationToken)
    {
        var applicationRoles = await _roleRepository.GetPaginatedRolesAsync(request.PageNumber, request.PageSize);

        IEnumerable<RoleDTO> roles = _mapper.Map<IEnumerable<RoleDTO>>(applicationRoles);

        var count = await _roleRepository.GetRolesCountAsync();
        var totalPages = (int)Math.Ceiling(count / (double)request.PageSize);

        return new PaginatedResult<RoleDTO>
        {
            Collection = roles,
            CurrentPage = request.PageNumber,
            PageSize = request.PageSize,
            TotalPageCount = totalPages,
            TotalItemCount = count,
        };
    }
}
