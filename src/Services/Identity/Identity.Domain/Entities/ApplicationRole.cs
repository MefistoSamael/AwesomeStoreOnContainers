using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Entities;

public class ApplicationRole : IdentityRole
{
    public ApplicationRole()
    {
    }
    public ApplicationRole(string roleName)
        : base(roleName)
    {
        NormalizedName = roleName.ToUpper();
    }

    private string? name;

    override public string? Name
    {
        get
        {
            return name;
        }

        set
        {
            if (value is not null)
            {
                NormalizedName = value.ToUpper();
                name = value;
            }
            else
            {
                NormalizedName = null;
                name = null;
            }
        }
    }
}
