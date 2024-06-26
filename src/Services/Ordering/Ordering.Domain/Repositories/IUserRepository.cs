using Ordering.Domain.Abstractions;
using Ordering.Domain.Entities;

namespace Ordering.Domain.Repositories;
public interface IUserRepository : IGenericRepository<User>
{
    public Task<User?> GetUserById(string orderId, CancellationToken cancellationToken = default);
}
