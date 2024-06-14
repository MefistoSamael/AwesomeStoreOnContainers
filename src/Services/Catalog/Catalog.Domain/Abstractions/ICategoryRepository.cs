using Catalog.Domain.Entities;

namespace Catalog.Domain.Abstractions;

public interface ICategoryRepository
{
    Task<string> CreateCategoryAsync(Category category, CancellationToken cancellationToken);

    Task<string> UpdateCategoryAsync(Category category, CancellationToken cancellationToken);

    Task DeleteCategoryAsync(Category category, CancellationToken cancellationToken);

    Task<Category?> GetCategoryByNameAsync(string categoryName, CancellationToken cancellationToken);

    Task<IEnumerable<Category>> GetPaginatedCategoriesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

    Task<int> GetCategoriesCountAsync(CancellationToken cancellationToken);

    Task<Category?> GetCategoryByIdAsync(string id, CancellationToken cancellationToken);

    Task<bool> HasProductsAsync(Category category, CancellationToken cancellationToken);
}
