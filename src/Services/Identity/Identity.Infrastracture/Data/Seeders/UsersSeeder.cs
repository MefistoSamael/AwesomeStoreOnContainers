using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastracture.Data.Seeders;

public static class UsersSeeder
{
    public static void SeedUsers(ModelBuilder builder)
    {
        var admin = new ApplicationUser
        {
            Id = "b74ddd14-6340-4840-95c2-db12554843e5",
            Email = "admin@gmail.com",
            NormalizedEmail = "admin@gmail.com".ToUpper(),
            LockoutEnabled = false,
            UserName = "admin@gmail.com",
            NormalizedUserName = "admin@gmail.com".ToUpper(),
        };
        var buyer = new ApplicationUser
        {
            Id = "0078F440-C7A4-4445-94C0-350F23700AA0",
            Email = "buyer@gmail.com",
            NormalizedEmail = "buyer@gmail.com".ToUpper(),
            LockoutEnabled = false,
            UserName = "buyer@gmail.com",
            NormalizedUserName = "buyer@gmail.com".ToUpper(),
        };
        var employee = new ApplicationUser
        {
            Id = "40F21EAF-2807-4EF3-8506-84FAF53A2190",
            Email = "employee@gmail.com",
            NormalizedEmail = "employee@gmail.com".ToUpper(),
            LockoutEnabled = false,
            UserName = "employee@gmail.com",
            NormalizedUserName = "employee@gmail.com".ToUpper()
        };

        PasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();

        admin.PasswordHash = _passwordHasher.HashPassword(admin, "Admin123");
        buyer.PasswordHash = _passwordHasher.HashPassword(buyer, "Buyer123");
        employee.PasswordHash = _passwordHasher.HashPassword(employee, "Employee123");


        builder.Entity<ApplicationUser>().HasData(admin, buyer, employee);
    }
}
