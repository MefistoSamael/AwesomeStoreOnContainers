using Identity.Application.Common.Options;
using Identity.Infrastracture.Authentication;
using Microsoft.Extensions.Options;

namespace Identity.Presentation.OptionsSetup;

public class PaginationOptionsSetup : IConfigureOptions<PaginationOptions>
{
    private const string sectionName = "PaginationParameters";
    private readonly IConfiguration _configuration;

    public PaginationOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(PaginationOptions options)
    {
        _configuration.GetSection(sectionName).Bind(options);
    }
}

