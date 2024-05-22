using Identity.Domain.Entities;
using Identity.Domain.Models;
using Identity.Infrastracture.Data.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastracture.Data;

public class ApplicationDbContext :
    IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
    base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        UsersSeeder.SeedUsers(builder);
        RolesSeeder.SeedRoles(builder);
        UserRolesSeeder.SeedUserRoles(builder);
    }
}
