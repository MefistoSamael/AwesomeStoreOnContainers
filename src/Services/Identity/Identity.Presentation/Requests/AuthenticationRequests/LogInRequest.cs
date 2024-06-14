namespace Identity.Presentation.Requests.AuthenticationRequests;

public class LogInRequest
{
    required public string Email { get; set; }

    required public string Password { get; set; }
}