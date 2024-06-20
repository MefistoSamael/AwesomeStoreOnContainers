using Identity.Application.Common.Options;
using Microsoft.Extensions.Options;

namespace Identity.Presentation.OptionsSetup;

public class PaginationOptionsSetup : IConfigureOptions<PaginationOptions>
{
    private const string SectionName = "PaginationParameters";
    private readonly IConfiguration _configuration;

    public PaginationOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(PaginationOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}
