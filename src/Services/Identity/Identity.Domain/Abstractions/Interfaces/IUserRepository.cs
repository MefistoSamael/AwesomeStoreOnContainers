using Identity.Domain.Entities;
using Identity.Domain.Models;

namespace Identity.Domain.Abstractions.Interfaces
{
    public interface IUserRepository
    {
        Task<string> CreateUserAsync(ApplicationUser model, string roleName);

        Task DeleteUserAsync(string userId);

        Task<ApplicationUser?> GetUserByEmailAsync(string email);

        Task<ApplicationUser?> GetUserByUserNameAsync(string email);

        public Task<IEnumerable<string>> GetUserRolesAsync(string userId);
    }
}
