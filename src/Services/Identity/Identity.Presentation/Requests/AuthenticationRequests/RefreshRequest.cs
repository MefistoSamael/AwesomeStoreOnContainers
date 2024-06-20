namespace Identity.Presentation.Requests.AuthenticationRequests;

public class RefreshRequest
{
    required public string AccessToken { get; set; }

    required public string RefreshToken { get; set; }
}
