using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities;
using Ordering.Domain.Repositories;
using Ordering.Infrastructure.Specifications.OrderSpecification;
using Ordering.Infrastructure.Specifications.UserSpecification;

namespace Ordering.Infrastructure.Repositories.EntityRepository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<User?> GetUserById(string userId, CancellationToken cancellationToken = default)
    {
        var user = await ApplySpecification(new UserByIdSpecification(userId))
            .SingleOrDefaultAsync(cancellationToken);

        return user;
    }
}
