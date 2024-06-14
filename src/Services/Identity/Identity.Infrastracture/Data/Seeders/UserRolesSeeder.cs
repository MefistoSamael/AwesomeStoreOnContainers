using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastracture.Data.Seeders;

public static class UserRolesSeeder
{
    public static void SeedUserRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" },
                new IdentityUserRole<string>() { RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330", UserId = "0078F440-C7A4-4445-94C0-350F23700AA0" },
                new IdentityUserRole<string>() { RoleId = "C262F33A-0F33-4B7B-9DB7-7581AEA78EAB", UserId = "40F21EAF-2807-4EF3-8506-84FAF53A2190" }
            );
    }
}
