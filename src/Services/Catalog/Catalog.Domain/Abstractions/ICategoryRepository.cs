using Catalog.Domain.Entities;

namespace Catalog.Domain.Abstractions;

public interface ICategoryRepository
{
    Task<string> CreateCategoryAsync(Category product);

    Task<string> UpdateCategoryAsync(Category product);

    Task DeleteCategoryAsync(Category product);


    Task<Category> GetCategoryByIdAsync(string id);
    
    Task<Category> GetCategoryByNameAsync(string categoryName);

    Task<IEnumerable<Category>> GetPaginatedCategoriesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

    Task<int> GetCategoriesCountAsync(CancellationToken cancellationToken);
}
