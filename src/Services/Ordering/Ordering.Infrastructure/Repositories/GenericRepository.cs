using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Abstractions;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Specifications.Common;

namespace Ordering.Infrastructure.Repositories;

[System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "properties are useless here")]
public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : Entity
{
    protected readonly DbContext _context;

    protected readonly DbSet<TEntity> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task CreateAsync(TEntity item, CancellationToken cancellationToken)
    {
        _dbSet.Add(item);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filters, CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking()
                                 .FirstOrDefaultAsync(filters, cancellationToken);
    }

    public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filters, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query = Include(includeProperties);

        return await query.FirstOrDefaultAsync(filters, cancellationToken);
    }

    public async Task<int> GetCountAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.CountAsync(cancellationToken);
    }

    public async Task RemoveAsync(TEntity item, CancellationToken cancellationToken)
    {
        _dbSet.Remove(item);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filters, CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking()
                                 .SingleOrDefaultAsync(filters, cancellationToken);
    }

    public async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filters, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query = Include(includeProperties);

        return await query.SingleOrDefaultAsync(filters, cancellationToken);
    }

    public async Task UpdateAsync(TEntity item, CancellationToken cancellationToken)
    {
        _dbSet.Update(item);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> filters, CancellationToken cancellationToken)
    {
        return await _dbSet.Where(filters).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> filters, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query = Include(includeProperties);

        return await query.Where(filters).ToListAsync(cancellationToken);
    }

    protected IQueryable<TEntity> ApplySpecification(Specification<TEntity> specification)
    {
        return SpecificationEvaluator.GetQuery(_dbSet, specification);
    }

    private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
}
