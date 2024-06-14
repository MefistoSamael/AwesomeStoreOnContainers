using Ordering.Application.Services;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Services;

public class GRPCProductService : IProductService
{
    public Task<Product?> GetProductByIdAsync(string productId)
    {
        throw new NotImplementedException();
    }
}
