using Identity.Application.Common.Models;
using Identity.Domain.Entities;
using System.Security.Claims;

namespace Identity.Application.Providers;

public interface IJwtProvider
{
    Task<TokenResult> GenerateJwt(ApplicationUser user);

    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}
