using Identity.Infrastracture.Authentication;
using Microsoft.Extensions.Options;

namespace Identity.Presentation.OptionsSetup;

public class RefreshTokenOptionsSetup : IConfigureOptions<RefreshTokenOptions>
{
    private const string sectionName = "RefreshToken";
    private readonly IConfiguration _configuration;

    public RefreshTokenOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(RefreshTokenOptions options)
    {
        _configuration.GetSection(sectionName).Bind(options);
    }
}
