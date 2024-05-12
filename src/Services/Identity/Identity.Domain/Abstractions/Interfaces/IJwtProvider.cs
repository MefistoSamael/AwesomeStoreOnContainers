using Identity.Domain.Models;

namespace Identity.Domain.Abstractions.Interfaces;

public interface IJwtProvider
{
    Task<string> Generate(ApplicationUser user);
}
