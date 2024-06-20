using System.Security.Claims;
using Identity.Application.Common.Models;
using Identity.Domain.Entities;

namespace Identity.Application.Providers;

public interface IJwtProvider
{
    Task<TokenResult> GenerateJwt(ApplicationUser user);

    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}
