using Ordering.Application.Common.Models;

namespace Ordering.Application.Services;
public interface IProductService
{
    public Task<ProductResponse?> GetProductByIdAsync(string productId);
}
