using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() { }
        public ApplicationRole(string roleName) : base(roleName)
        {
            NormalizedName = roleName.ToUpper();
        }
    }
}
