using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities;
using System.Linq;

namespace Ordering.Infrastructure.Specifications.Common;

public static class SpecificationEvaluator
{
    public static IQueryable<TEntity> GetQuery<TEntity>(
        IQueryable<TEntity> inputQueryable,
        Specification<TEntity> specification)
        where TEntity : Entity
    {
        IQueryable<TEntity> queryable = inputQueryable;

        if (specification.Criteria is not null)
        {
            queryable = queryable.Where(specification.Criteria);
        }

        queryable = specification.IncludeExpressions.Aggregate(
            queryable,
            (current, includeExpression) =>
                current.Include(includeExpression));

        if (specification.OrderByExpression is not null)
        {
            queryable = queryable.OrderBy(specification.OrderByExpression);
        }
        else if (specification.OrderByDescendingExpression is not null)
        {
            queryable = queryable.OrderByDescending(specification.OrderByDescendingExpression);
        }

        if (specification.PageNumber > 0 &&
            specification.PageSize > 0)
        {
            queryable = queryable.Skip((specification.PageNumber - 1) * specification.PageSize)
                                  .Take(specification.PageSize);
        }

        if (specification.IsNoTrackingQuery)
        {
            queryable = queryable.AsNoTracking();
        }

        return queryable;
    }
}
