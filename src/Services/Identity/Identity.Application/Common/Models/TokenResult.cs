namespace Identity.Application.Common.Models;

public class TokenResult
{
    required public string Token { get; set; }

    required public DateTime Expiry { get; set; }
}
