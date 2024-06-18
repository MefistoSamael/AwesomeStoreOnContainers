using Ordering.Domain.Entities;
using Ordering.Domain.Repositories;

namespace Ordering.Infrastructure.Repositories.EntityRepository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}
