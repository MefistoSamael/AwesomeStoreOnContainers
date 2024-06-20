namespace Identity.Application.Common.Models;

public class TokensResponse
{
    required public string JwtToken { get; set; }

    required public string RefreshToken { get; set; }
}
