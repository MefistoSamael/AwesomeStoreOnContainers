using System.Linq.Expressions;

namespace Ordering.Domain.Abstractions;
public interface IRepository<T>
    where T : class
{
    public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filters, CancellationToken cancellationToken);

    public Task<T> SingleAsync(Expression<Func<T, bool>> filters, CancellationToken cancellationToken);

    public Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> filters, CancellationToken cancellationToken);

    public Task<IEnumerable<T>> Where(Expression<Func<T, bool>> filters, CancellationToken cancellationToken);
}
