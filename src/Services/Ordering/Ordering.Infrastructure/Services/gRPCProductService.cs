using Ordering.Application.Services;
using ProductResponse = Ordering.Application.Common.Models.ProductResponse;

namespace Ordering.Infrastructure.Services;

public class GRPCProductService : IProductService
{
    public async Task<ProductResponse?> GetProductByIdAsync(string productId)
    {
        return new ProductResponse
        { Id = productId, Name = "Product", ImageUri = "https://image.com", Price = 100, Categoties = "Fence, wood" };
    }
}
