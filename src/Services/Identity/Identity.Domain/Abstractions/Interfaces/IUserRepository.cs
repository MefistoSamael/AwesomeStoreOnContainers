using Identity.Domain.Models;

namespace Identity.Domain.Abstractions.Interfaces
{
    public interface IUserRepository
    {
        Task<string> CreateUserAsync(ApplicationUser model);

        Task<string> AddToRoleAsync(ApplicationUser user, string roleName);

        Task<string> RemoveFromRoleAsync(ApplicationUser user, string roleName);

        Task DeleteUserAsync(string userId);

        Task<ApplicationUser?> GetUserByEmailAsync(string email);

        Task<ApplicationUser?> GetUserByUserNameAsync(string email);

        public Task <string> GetUserRoleAsync(string userId);

        public Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        
        Task<ApplicationUser?> GetUserByIdAsync(string id);
    }
}
