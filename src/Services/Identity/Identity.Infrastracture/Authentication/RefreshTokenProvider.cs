using Identity.Application.Common.Models;
using Identity.Domain.Abstractions.Interfaces;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace Identity.Infrastracture.Authentication;

public class RefreshTokenProvider : IRefreshTokenProvider
{
    private readonly RefreshTokenOptions _options;

    public RefreshTokenProvider(IOptions<RefreshTokenOptions> options)
    {
        _options = options.Value;
    }

    public TokenResult Genereate()
    {
        var randomNumber = new byte[64];

        using var generator = RandomNumberGenerator.Create();

        generator.GetBytes(randomNumber);

        return new TokenResult
        {
            Expiry = DateTime.UtcNow.AddMinutes(_options.RefreshTokenLifeTime),
            Token = Convert.ToBase64String(randomNumber)
        };
    }
}
