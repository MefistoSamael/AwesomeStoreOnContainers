namespace Identity.Presentation.Requests.AuthenticationRequests;

public class RegisterRequest
{
    required public string Email { get; set; }

    required public string Password { get; set; }
}