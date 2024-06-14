using Identity.Domain.Entities;

namespace Identity.Domain.Abstractions.Interfaces;

public interface IRoleRepository
{
    public Task<ApplicationRole?> GetRoleByIdAsync(string roleId);

    public Task<ApplicationRole?> GetRoleByNameAsync(string roleName);

    public Task<IEnumerable<ApplicationRole>> GetAllRolesAsync(CancellationToken cancellationToken);

    public Task<IEnumerable<ApplicationRole>> GetPaginatedRolesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

    public Task<int> GetRolesCountAsync(CancellationToken cancellationToken);
}
