using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastracture.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string?> CreateUserAsync(ApplicationUser model)
        {
            await _userManager.CreateAsync(model);
            var result = await _userManager.AddPasswordAsync(model, model.PasswordHash);
            return model.Id;
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is not null)
                await _userManager.DeleteAsync(user);
        }

        public Task<ApplicationUser> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
