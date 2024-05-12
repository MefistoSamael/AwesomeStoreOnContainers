using Identity.Domain.Entities;
using Identity.Domain.Models;
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
        
        SeedUsers(builder);
        SeedRoles(builder);
        SeedUserRoles(builder);
    }

    private void SeedUsers(ModelBuilder builder)
    {

        var admin = new ApplicationUser
        {
            Id = "b74ddd14-6340-4840-95c2-db12554843e5",
            Email = "admin@gmail.com",
            LockoutEnabled = false,
        };
        var buyer = new ApplicationUser
        {
            Id = "0078F440-C7A4-4445-94C0-350F23700AA0",
            Email = "buyer@gmail.com",
            LockoutEnabled = false,
        };
        var employee = new ApplicationUser
        {
            Id = "40F21EAF-2807-4EF3-8506-84FAF53A2190",
            Email = "employee@gmail.com",
            LockoutEnabled = false,
        };

        PasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();

        admin.PasswordHash = _passwordHasher.HashPassword(admin, "Admin123");
        buyer.PasswordHash = _passwordHasher.HashPassword(buyer, "Buyer123");
        employee.PasswordHash = _passwordHasher.HashPassword(employee, "Employee123");


        builder.Entity<ApplicationUser>().HasData(admin, buyer, employee);
    }

    private void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<ApplicationRole>().HasData(
            new ApplicationRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
            new ApplicationRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "Buyer", ConcurrencyStamp = "2", NormalizedName = "BUYER" },
            new ApplicationRole() { Id = "C262F33A-0F33-4B7B-9DB7-7581AEA78EAB", Name = "Employee", ConcurrencyStamp = "3", NormalizedName = "EMPLOYEE" }
            );
    }

    private void SeedUserRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" },
                new IdentityUserRole<string>() { RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330", UserId = "0078F440-C7A4-4445-94C0-350F23700AA0" },
                new IdentityUserRole<string>() { RoleId = "C262F33A-0F33-4B7B-9DB7-7581AEA78EAB", UserId = "40F21EAF-2807-4EF3-8506-84FAF53A2190" }
            );
    }
}
