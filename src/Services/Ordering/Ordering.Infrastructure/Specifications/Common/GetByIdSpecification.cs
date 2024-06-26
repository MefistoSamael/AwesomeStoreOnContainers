using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Specifications.Common;

public abstract class GetByIdSpecification<TEntity> : Specification<TEntity>
    where TEntity : Entity
{
    public GetByIdSpecification(string id)
        : base(entity => entity.Id == id)
    {
    }
}
