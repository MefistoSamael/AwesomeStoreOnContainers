using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }
        public ApplicationUser(string email, string username, string password) 
        {
            Email = email;
            NormalizedEmail = email.ToUpper();

            UserName = username;
            NormalizedUserName = username.ToUpper();

            PasswordHash = password;
        }
    }
}
