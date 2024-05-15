using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Models;

public class ApplicationUser : IdentityUser
{
    public string? RefreshToken { get; set; }

    public DateTime RefreshTokenExpiry { get; set; }

    public ApplicationUser() { }

    public ApplicationUser(string email, string password)
    {
        Email = email;
        NormalizedEmail = email.ToUpper();

        UserName = email;
        NormalizedUserName = email.ToUpper();

        PasswordHash = password;
    }
}
