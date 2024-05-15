using Identity.Application.Common.Models;
using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace Identity.Infrastracture.Authentication;

internal class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;
    private readonly IUserRepository _userRepository;

    public JwtProvider(IOptions<JwtOptions> options, IUserRepository userRepository)
    {
        _options = options.Value;
        _userRepository = userRepository;
    }

    public async Task<TokenResult> GenerateJwt(ApplicationUser user)
    {
        var role = await _userRepository.GetUserRoleAsync(user.Id);

        var claims = new Claim[] 
        {
            new (JwtRegisteredClaimNames.Sub, user.Id),
            new (JwtRegisteredClaimNames.Email, user.Email),
            new ("role", role),
        };

        var expiryDate = DateTime.UtcNow.AddMinutes(_options.JwtTokenLifeTime);

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.SecretKey)), 
            SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _options.Issuer, 
            _options.Audience,
            claims,
            null,
            expiryDate,
            signingCredentials);

        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return new TokenResult
        {
            Token = tokenValue,
            Expiry = expiryDate,
        };
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
    {
        var secret = _options.SecretKey;

        var validation = new TokenValidationParameters
        {
            ValidIssuer = _options.Issuer,
            ValidAudience = _options.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
            ValidateLifetime = false
        };

        return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
    }
}
