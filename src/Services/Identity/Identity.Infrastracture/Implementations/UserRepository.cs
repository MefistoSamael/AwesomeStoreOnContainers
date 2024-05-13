using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastracture.Implementations;

public class UserRepository : IUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserRepository(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> CreateUserAsync(ApplicationUser model)
    {
        model.Id = Guid.NewGuid().ToString();
        model.ConcurrencyStamp = Guid.NewGuid().ToString();
        await _userManager.CreateAsync(model);
        await _userManager.AddPasswordAsync(model, model.PasswordHash!);

        return model.Id;
    }

    public async Task DeleteUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
     
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

        return (await _userManager.GetRolesAsync(user)).Single();
    }

    public async Task<ApplicationUser?> GetUserByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        return user;
    }

    public async Task<string> AddToRoleAsync(ApplicationUser user, string roleName)
    {
        user.ConcurrencyStamp = Guid.NewGuid().ToString();

        IdentityResult roleResult = await _userManager.AddToRoleAsync(user, roleName);

        return user.Id;
    }

    public async Task<string> RemoveFromRoleAsync(ApplicationUser user, string roleName)
    {
        user.ConcurrencyStamp = Guid.NewGuid().ToString();

        IdentityResult roleResult = await _userManager.RemoveFromRoleAsync(user, roleName);

        return user.Id;
    }

    public async Task<IEnumerable<ApplicationUser>> GetPaginatedUsersAsync(int pageNumber, int pageSize)
    {
        return await _userManager.Users.OrderBy(u => u.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> GetUsersCountAsync()
    {
        return await _userManager.Users.CountAsync();
    }
}
