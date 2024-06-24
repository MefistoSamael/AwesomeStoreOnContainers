using Catalog.Domain.Entities;

namespace Catalog.Domain.Abstractions;

public interface IProductRepostitory : IBaseRepostitory<Product>
{
    Task<IEnumerable<Product>> GetAllAsync(CancellationToken? cancellationToken);
}