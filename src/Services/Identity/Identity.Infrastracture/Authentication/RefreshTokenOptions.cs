namespace Identity.Infrastracture.Authentication;

public class RefreshTokenOptions
{
    required public int RefreshTokenLifeTime { get; set; }
}