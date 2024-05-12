using Identity.Domain.Entities;

namespace Identity.Domain.Extensions;

public static class ApplicationRoleIenumerableExtension
{
    public static string RolesToString(this IEnumerable<ApplicationRole> roles, string separator = " ")
    {
        return String.Join(separator, roles.Select(i => i.Name).ToArray());
    }
}
