using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Ordering.Domain.Entities;
using System.Linq.Expressions;

namespace Ordering.Infrastructure.Specifications.Common;

public abstract class Specification<TEntity>
    where TEntity : Entity
{
    protected Specification(Expression<Func<TEntity, bool>>? criteria) =>
        Criteria = criteria;

    public Expression<Func<TEntity, bool>>? Criteria { get; private set; }

    public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new();

    public Expression<Func<TEntity, object>>? OrderByExpression { get; private set; }

    public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; private set; }

    public int PageNumber { get; protected set; }

    public int PageSize { get; protected set; }

    public bool IsNoTrackingQuery { get; protected set; } = false;

    protected void AddCriteria(
        Expression<Func<TEntity, bool>> criteria) =>
        Criteria = criteria;

    protected void AddInclude(
        Expression<Func<TEntity, object>> includeExpression) =>
        IncludeExpressions.Add(includeExpression);

    protected void AddOrderBy(
        Expression<Func<TEntity, object>> orderByExpression) =>
        OrderByExpression = orderByExpression;

    protected void AddorderByDescending(
        Expression<Func<TEntity, object>> orderByDescendingExpression) =>
        OrderByDescendingExpression = orderByDescendingExpression;
}