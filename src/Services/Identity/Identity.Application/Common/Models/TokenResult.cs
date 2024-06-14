namespace Identity.Application.Common.Models;

public class TokenResult
{
    public required string Token { get; set; }

    public required DateTime Expiry { get; set; }
}
