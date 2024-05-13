using Identity.Domain.Entities;

namespace Identity.Domain.Abstractions.Interfaces;

public interface IRoleRepository
{
    public Task<ApplicationRole?> GetRoleByIdAsync(string roleId);
    
    public Task<ApplicationRole?> GetRoleByNameAsync(string roleName);

    public Task<string> CreateRoleAsync(ApplicationRole role);

    public Task DeleteRoleAsync(string roleId);

    public Task<IEnumerable<ApplicationRole>> GetAllRolesAsync();

    public Task<bool> HasUsers(string roleId);

    Task<string> UpdateRoleAsync(ApplicationRole role);
}
