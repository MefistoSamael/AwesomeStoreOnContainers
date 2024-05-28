using Catalog.Domain.Entities;

namespace Catalog.Domain.Abstractions;

public interface ICategoryRepository
{
    Task<string> CreateCategoryAsync(Category product, CancellationToken cancellationToken);

    Task<string> UpdateCategoryAsync(Category product, CancellationToken cancellationToken);

    Task DeleteCategoryAsync(Category product, CancellationToken cancellationToken);

    
    Task<Category?> GetCategoryByNameAsync(string categoryName, CancellationToken cancellationToken);

    Task<IEnumerable<Category>> GetPaginatedCategoriesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

    Task<int> GetCategoriesCountAsync(CancellationToken cancellationToken);
    Task<Category?> GetCategoryByIdAsync(string id, CancellationToken cancellationToken);
}
