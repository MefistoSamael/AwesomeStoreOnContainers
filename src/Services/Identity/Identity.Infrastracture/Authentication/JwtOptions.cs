namespace Identity.Infrastracture.Authentication;

public class JwtOptions
{
    required public string Issuer { get; init; }

    required public string Audience { get; init; }

    required public string SecretKey { get; init; }

    required public int JwtTokenLifeTime { get; init; }
}
