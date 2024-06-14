using Ordering.Application.Services;

namespace Ordering.Infrastructure.Services;

public class gRPCUserService : IUserService
{
    public Task<bool> IsExistsUserAsync(string userId)
    {
        throw new NotImplementedException();
    }
}
