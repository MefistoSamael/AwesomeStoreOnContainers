using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Entities;
using MediatR;

namespace Identity.Application.UseCases.RoleCrud.GetRoleById;

public class GetRoleByIdInteractor : IRequestHandler<GetRoleByIdUseCase, ApplicationRole?>
{
    private readonly IRoleRepository _roleRepository;

    public GetRoleByIdInteractor(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<ApplicationRole?> Handle(GetRoleByIdUseCase request, CancellationToken cancellationToken)
    {
        return await _roleRepository.GetRoleAsync(request.RoleId);
    }
}
