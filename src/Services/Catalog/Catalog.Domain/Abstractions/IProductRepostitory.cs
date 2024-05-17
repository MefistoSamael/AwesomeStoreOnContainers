using Catalog.Domain.Entities;

namespace Catalog.Domain.Abstractions
{
    public interface IProductRepostitory
    {
        Task<string> CreateProductAsync(Product product);

        Task<string> UpdateProductAsync(Product product);

        Task DeleteProductAsync(Product product);


        Task<string> AddToTypeAsync(Product product, string typeName);

        Task<string> AddToTypesAsync(Product product, IEnumerable<string> typeName);

        Task<string> RemoveFromTypeAsync(Product product, string typeName);

        Task<string> RemoveFromTypesAsync(Product product, IEnumerable<string> typeName);


        Task<Product> GetProductByIdAsync(string id);

        Task<IEnumerable<Product>> GetPaginatedProductsAsync();
    }
}
