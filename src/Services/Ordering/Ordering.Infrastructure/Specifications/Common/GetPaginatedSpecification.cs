using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Specifications.Common;

public abstract class GetPaginatedSpecification<TEntity> : Specification<TEntity>
    where TEntity : Entity
{
    public GetPaginatedSpecification(int pageNumber, int pageSize)
        : base(null)
    {
        AddOrderBy(entity => entity.Id);

        PageNumber = pageNumber;
        PageNumber = pageSize;

        IsNoTrackingQuery = true;
    }
}
