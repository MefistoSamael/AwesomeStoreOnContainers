using Microsoft.Extensions.Options;
using Ordering.Infrastructure.Options;

namespace Ordering.Presentation.Common.OptionsSetup;

public class GrpcConnectionOptionsSetup : IConfigureOptions<GrpcConnectionOptions>
{
    private readonly IConfiguration _configuration;

    public GrpcConnectionOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(GrpcConnectionOptions options)
    {
        options.ConnectionString = _configuration["GrpcConnectionOptions:ConnectionString"]!;
    }
}