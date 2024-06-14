using Identity.Application.Common.Models;
using Identity.Domain.Models;
using System.Security.Claims;

namespace Identity.Domain.Abstractions.Interfaces;

public interface IJwtProvider
{
    Task<TokenResult> GenerateJwt(ApplicationUser user);

    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}
