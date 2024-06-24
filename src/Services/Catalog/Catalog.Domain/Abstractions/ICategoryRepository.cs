using Catalog.Domain.Entities;

namespace Catalog.Domain.Abstractions;

public interface ICategoryRepository : IBaseRepostitory<Category>
{
    Task<Category?> GetByNameAsync(string categoryName, CancellationToken cancellationToken);

    Task<bool> HasProductsAsync(Category category, CancellationToken cancellationToken);
}
