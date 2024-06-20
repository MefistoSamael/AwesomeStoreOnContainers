using Identity.Domain.Entities;

namespace Identity.Domain.Abstractions.Interfaces;

public interface IUserRepository
{
    public Task<string> CreateUserAsync(ApplicationUser model);

    public Task<string> AddToRoleAsync(ApplicationUser user, string roleName);

    public Task<string> RemoveFromRoleAsync(ApplicationUser user, string roleName);

    public Task<string> UpdateUserRole(ApplicationUser user, string roleName, CancellationToken cancellationToken);

    public Task DeleteUserAsync(string userId);

    public Task<ApplicationUser?> GetUserByEmailAsync(string email);

    public Task<string?> GetUserRoleAsync(string userId);

    public Task<IEnumerable<ApplicationUser>> GetPaginatedUsersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

    public Task<ApplicationUser?> GetUserByIdAsync(string id);

    public Task<int> GetUsersCountAsync(CancellationToken cancellationToken);

    public Task UpdateUser(ApplicationUser user);
}
