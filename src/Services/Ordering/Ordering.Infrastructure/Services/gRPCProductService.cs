using Ordering.Application.Common.Models;
using Ordering.Application.Services;

namespace Ordering.Infrastructure.Services;

public class GRPCProductService : IProductService
{
    public Task<ProductResponse?> GetProductByIdAsync(string productId)
    {
        throw new NotImplementedException();
    }
}
