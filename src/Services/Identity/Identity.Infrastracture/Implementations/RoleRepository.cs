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

    public async Task<IEnumerable<ApplicationRole>> GetAllRolesAsync(CancellationToken cancellationToken)
    {
        return await _roleManager.Roles.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<ApplicationRole>> GetPaginatedRolesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await _roleManager.Roles.OrderBy(role => role.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<ApplicationRole?> GetRoleByIdAsync(string roleId)
    {
        return await _roleManager.FindByIdAsync(roleId);
    }

    public async Task<ApplicationRole?> GetRoleByNameAsync(string roleName)
    {
        return await _roleManager.FindByNameAsync(roleName);
    }

    public async Task<int> GetRolesCountAsync(CancellationToken cancellationToken)
    {
        return await _roleManager.Roles.CountAsync(cancellationToken);
    }
}
