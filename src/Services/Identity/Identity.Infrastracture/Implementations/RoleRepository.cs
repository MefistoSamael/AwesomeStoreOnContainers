using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastracture.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        
        public RoleRepository()
        {

        }
        public Task<string> CreateRoleAsync(ApplicationRole role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRoleAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationRole> GetRoleAsync(string roleId)
        {
            throw new NotImplementedException();
        }
    }
}
