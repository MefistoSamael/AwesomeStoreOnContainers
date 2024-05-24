using Catalog.Domain.Entities;

namespace Catalog.Domain.Abstractions;

public interface IProductRepostitory
{
    Task<string> CreateProductAsync(Product product);

    Task<string> UpdateProductAsync(Product product);

    Task DeleteProductAsync(Product product);


    Task<string> AddToCategoryAsync(Product product, string categoryName);

    Task<string> AddToCategoriesAsync(Product product, IEnumerable<string> categoryName);

    Task<string> RemoveFromCategoryAsync(Product product, string categoryName);

    Task<string> RemoveFromCategoriesAsync(Product product, IEnumerable<string> categoryName);


    Task<Product> GetProductByIdAsync(string id);

    Task<IEnumerable<Product>> GetPaginatedProductsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

    Task<int> GetProductCountAsync(CancellationToken cancellationToken);
}
