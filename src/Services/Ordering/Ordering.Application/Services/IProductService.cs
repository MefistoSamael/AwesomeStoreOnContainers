using Ordering.Domain.Entities;

namespace Ordering.Application.Services;
public interface IProductService
{
    public Task<Product?> GetProductByIdAsync(string productId);
}
