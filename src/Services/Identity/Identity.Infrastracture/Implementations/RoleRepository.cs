using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Identity.Infrastracture.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleRepository(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<string> CreateRoleAsync(ApplicationRole role)
        {
            role.Id = Guid.NewGuid().ToString();
            await _roleManager.CreateAsync(role);

            return role.Id;
        }

        public async Task DeleteRoleAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role is null)
                return;

            await _roleManager.DeleteAsync(role);
        }

        public async Task<IEnumerable<ApplicationRole>> GetAllRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public Task<ApplicationRole?> GetRoleAsync(string roleId)
        {
            return _roleManager.FindByIdAsync(roleId);
        }
    }
}
