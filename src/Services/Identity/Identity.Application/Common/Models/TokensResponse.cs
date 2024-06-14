namespace Identity.Application.Common.Models;

public class TokensResponse
{
    public required string JwtToken { get; set; }

    public required string RefreshToken { get; set; }
}
