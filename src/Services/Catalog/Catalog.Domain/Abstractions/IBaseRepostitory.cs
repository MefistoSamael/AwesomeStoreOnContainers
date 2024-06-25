using Catalog.Domain.Entities;

namespace Catalog.Domain.Abstractions;
public interface IBaseRepostitory<TEntity>
    where TEntity : class
{
    Task<string> CreateAsync(TEntity entity, CancellationToken cancellationToken);

    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);

    Task<TEntity?> GetByIdAsync(string id, CancellationToken cancellationToken);

    Task<int> GetCountAsync(CancellationToken cancellationToken);

    Task<IEnumerable<TEntity>> GetPaginatedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

    Task<string> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
}