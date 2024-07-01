namespace Identity.Application.Common.Models;

public class UserDTO
{
    required public string Id { get; set; }

    required public string Email { get; set; }

    required public string RoleName { get; set; }
}
