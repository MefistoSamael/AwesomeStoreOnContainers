using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

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

            // FOR DEVELOPMENT PURPOSES ONLY
            if (!roleResult.Succeeded)
                throw new NotImplementedException($"Role {roleName} doesn't exists");

            return model.Id;
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            // FOR DEVELOPMENT PURPOSES ONLY
            if (user is null)
            {
                throw new ArgumentNullException("In user deletion id of non-exsistent user");
            }
         
            await _userManager.DeleteAsync(user);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser?> GetUserByUserNameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<string> GetUserRoleAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId); 
            
            if (user is null)
                throw new NotImplementedException("Handle me");

            return (await _userManager.GetRolesAsync(user)).Single();
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            return user;
        }
    }
}
