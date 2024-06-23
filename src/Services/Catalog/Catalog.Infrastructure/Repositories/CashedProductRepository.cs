using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Catalog.Infrastructure.Repositories;

public class CashedProductRepository : IProductRepostitory
{
    private readonly ProductRepository _decorated;
    private readonly IDistributedCache _distributedCache;

    public CashedProductRepository(ProductRepository decorated, IDistributedCache distributedCache)
    {
        _decorated = decorated;
        _distributedCache = distributedCache;
    }

    public async Task<string> CreateProductAsync(Product product, CancellationToken cancellationToken)
    {
        return await _decorated.CreateProductAsync(product, cancellationToken);
    }

    public async Task DeleteProductAsync(Product product, CancellationToken cancellationToken)
    {
        var key = $"productId-{product.Id}";

        string? cashedMember = await _distributedCache.GetStringAsync(
            key,
            cancellationToken);

        if (!string.IsNullOrEmpty(cashedMember))
        {
            await _distributedCache.RemoveAsync(
                key,
                cancellationToken);
        }

        await _decorated.DeleteProductAsync(product, cancellationToken);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken? cancellationToken)
    {
        return await _decorated.GetAllProductsAsync(cancellationToken);
    }

    public async Task<IEnumerable<Product>> GetPaginatedProductsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await _decorated.GetPaginatedProductsAsync(pageNumber, pageSize, cancellationToken);
    }

    public async Task<Product> GetProductByIdAsync(string id, CancellationToken cancellationToken)
    {
        var key = $"productId-{id}";

        string? cashedMember = await _distributedCache.GetStringAsync(
            key,
            cancellationToken);

        if (string.IsNullOrEmpty(cashedMember))
        {
            var member = await _decorated.GetProductByIdAsync(id, cancellationToken);

            if (member is null)
            {
                return member;
            }

            await _distributedCache.SetStringAsync(
                key,
                JsonConvert.SerializeObject(member),
                cancellationToken);

            return member;
        }

        return JsonConvert.DeserializeObject<Product>(cashedMember);
    }

    public async Task<int> GetProductCountAsync(CancellationToken cancellationToken)
    {
        return await _decorated.GetProductCountAsync(cancellationToken);
    }

    public async Task<string> UpdateProductAsync(Product product, CancellationToken cancellationToken)
    {
        var key = $"productId-{product.Id}";

        var answer = await _decorated.UpdateProductAsync(product, cancellationToken);

        if (!string.IsNullOrEmpty(await _distributedCache.GetStringAsync(
                key,
                cancellationToken)))
        {
            await _distributedCache.SetStringAsync(
                key,
                JsonConvert.SerializeObject(product),
                cancellationToken);
        }

        return answer;
    }
}