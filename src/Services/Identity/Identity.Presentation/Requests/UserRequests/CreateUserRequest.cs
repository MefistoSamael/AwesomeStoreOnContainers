namespace Identity.Presentation.Requests.UserRequests;

public class CreateUserRequest
{
    required public string Email { get; set; }

    required public string Password { get; set; }

    required public string Role { get; set; }
}