using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Entities;
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

        public async Task<string> CreateUserAsync(ApplicationUser model, string roleName)
        {
            model.Id = Guid.NewGuid().ToString();
            await _userManager.CreateAsync(model);
            await _userManager.AddPasswordAsync(model, model.PasswordHash!);
            IdentityResult roleResult = await _userManager.AddToRoleAsync(model, roleName);

            if (!roleResult.Succeeded)
                throw new NotImplementedException($"Role {roleName} doesn't exists");

            return model.Id;
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is not null)
                await _userManager.DeleteAsync(user);
        }

        public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser?> GetUserByUserNameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId); 
            
            if (user is null)
                throw new NotImplementedException("Handle me");

            return await _userManager.GetRolesAsync(user);
        }
    }
}
