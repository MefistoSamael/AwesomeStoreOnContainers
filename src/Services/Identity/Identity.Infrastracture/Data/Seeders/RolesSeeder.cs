using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastracture.Data.Seeders;

public static class RolesSeeder
{
    public static void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<ApplicationRole>().HasData(
            new ApplicationRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = RoleConstants.Admin, ConcurrencyStamp = "1", NormalizedName = RoleConstants.Admin.ToUpper() },
            new ApplicationRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = RoleConstants.Buyer, ConcurrencyStamp = "2", NormalizedName = RoleConstants.Buyer.ToUpper() },
            new ApplicationRole() { Id = "C262F33A-0F33-4B7B-9DB7-7581AEA78EAB", Name = RoleConstants.Employee, ConcurrencyStamp = "3", NormalizedName = RoleConstants.Employee.ToUpper() });
    }
}
