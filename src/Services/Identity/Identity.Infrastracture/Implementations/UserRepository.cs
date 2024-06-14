using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Entities;
using Identity.Infrastracture.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastracture.Implementations;

public class UserRepository : IUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public UserRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
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

        await _userManager.DeleteAsync(user!);
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

        return (await _userManager.GetRolesAsync(user!)).Single();
    }

    public async Task<ApplicationUser?> GetUserByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        return user;
    }

    public async Task<string> UpdateUserRole(ApplicationUser user, string roleName, CancellationToken cancellationToken)
    {
        var role = await _context.Roles.SingleAsync(r => r.Name == roleName, cancellationToken);

        var userRole = await _context.UserRoles.SingleAsync(ur => ur.UserId == user.Id, cancellationToken);

        userRole.RoleId = role.Id;

        _context.UserRoles.Update(userRole);

        await _context.SaveChangesAsync(cancellationToken);

        return user.Id;
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

    public async Task<IEnumerable<ApplicationUser>> GetPaginatedUsersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await _userManager.Users.OrderBy(u => u.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetUsersCountAsync(CancellationToken cancellationToken)
    {
        return await _userManager.Users.CountAsync(cancellationToken);
    }

    public async Task UpdateUser(ApplicationUser user)
    {
        await _userManager.UpdateAsync(user);
    }
}
