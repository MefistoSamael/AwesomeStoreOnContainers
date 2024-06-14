using Identity.Application.Common.Models;

namespace Identity.Domain.Abstractions.Interfaces;
public interface IRefreshTokenProvider
{
    TokenResult Genereate();
}
