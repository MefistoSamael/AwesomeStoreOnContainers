using Identity.Domain.Models;

namespace Identity.Domain.Abstractions.Interfaces
{
    public interface IUserRepository
    {
        Task<string?> CreateUserAsync(ApplicationUser model);

        Task DeleteUserAsync(string userId);

        Task<ApplicationUser> GetUserByEmail(string email);
    }
}
