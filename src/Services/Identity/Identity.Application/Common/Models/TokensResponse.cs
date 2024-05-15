namespace Identity.Application.Common.Models;

public class TokensResponse
{
    public required string JwtToken { get; set; }

    public required DateTime JwtExpiry { get; set; }

    public required string RefreshToken { get; set; }

    public required DateTime RefreshTokenExpiry { get; set; }

}
