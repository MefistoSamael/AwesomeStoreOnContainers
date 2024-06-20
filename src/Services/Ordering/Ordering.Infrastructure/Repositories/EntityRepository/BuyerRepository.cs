using Ordering.Domain.Entities;
using Ordering.Domain.Repositories;

namespace Ordering.Infrastructure.Repositories.EntityRepository;

public class BuyerRepository : GenericRepository<Buyer>, IBuyerRepository
{
    public BuyerRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}
