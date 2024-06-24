using Catalog.Domain.Entities;

namespace Catalog.Domain.Abstractions;

public interface IProductRepostitory
{
    Task<string> CreateProductAsync(Product product, CancellationToken cancellationToken);

    Task<string> UpdateProductAsync(Product product, CancellationToken cancellationToken);

    Task DeleteProductAsync(Product product, CancellationToken cancellationToken);

    Task<Product> GetProductByIdAsync(string id, CancellationToken cancellationToken);

    Task<IEnumerable<Product>> GetPaginatedProductsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

    Task<int> GetProductCountAsync(CancellationToken cancellationToken);

    Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken? cancellationToken);
}