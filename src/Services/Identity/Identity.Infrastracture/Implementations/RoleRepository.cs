using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Entities;
using Identity.Infrastracture.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastracture.Implementations;

public class RoleRepository : IRoleRepository
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly ApplicationDbContext _context;

    public RoleRepository(RoleManager<ApplicationRole> roleManager, ApplicationDbContext context)
    {
        _roleManager = roleManager;
        _context = context;
    }

    public async Task<IEnumerable<ApplicationRole>> GetAllRolesAsync()
    {
        return await _roleManager.Roles.ToListAsync();
    }

    public async Task<IEnumerable<ApplicationRole>> GetPaginatedRolesAsync(int pageNumber, int pageSize)
    {
        return await _roleManager.Roles.OrderBy(r => r.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public Task<ApplicationRole?> GetRoleByIdAsync(string roleId)
    {
        return _roleManager.FindByIdAsync(roleId);
    }

    public async Task<ApplicationRole?> GetRoleByNameAsync(string roleName)
    {
        return await _roleManager.FindByNameAsync(roleName);
    }

    public async Task<int> GetRolesCountAsync()
    {
        return await _roleManager.Roles.CountAsync();
    }

    public async Task<bool> HasUsers(string roleId)
    {
        return await _context.UserRoles.FirstOrDefaultAsync(ur => ur.RoleId == roleId) is not null;
    }

    //public async Task<string> UpdateRoleAsync(ApplicationRole role)
    //{
    //    role.ConcurrencyStamp = Guid.NewGuid().ToString();
    //    await _roleManager.UpdateAsync(role);

    //    return role.Id;
    //}

    //public async Task<string> CreateRoleAsync(ApplicationRole role)
    //{
    //    role.Id = Guid.NewGuid().ToString();
    //    role.ConcurrencyStamp = Guid.NewGuid().ToString();

    //    await _roleManager.CreateAsync(role);

    //    return role.Id;
    //}

    //public async Task DeleteRoleAsync(string roleId)
    //{
    //    var role = await _roleManager.FindByIdAsync(roleId);

    //    await _roleManager.DeleteAsync(role);
    //}
}
