using System.Linq.Expressions;
using System.Threading;

namespace Ordering.Domain.Abstractions;
public interface IGenericRepository<TEntity>
    where TEntity : class
{
    Task CreateAsync(TEntity item, CancellationToken cancellationToken);

    Task RemoveAsync(TEntity item, CancellationToken cancellationToken);

    Task UpdateAsync(TEntity item, CancellationToken cancellationToken);

    public Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filters, CancellationToken cancellationToken);

    public Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filters, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProperties);

    public Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filters, CancellationToken cancellationToken);

    public Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filters, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includeProperties);

    public Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> filters, CancellationToken cancellationToken);

    public Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> filters, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includeProperties);

    public Task<int> GetCountAsync(CancellationToken cancellationToken);
}
