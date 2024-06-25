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

    public async Task<string> CreateAsync(Product product, CancellationToken cancellationToken)
    {
        return await _decorated.CreateAsync(product, cancellationToken);
    }

    public async Task DeleteAsync(Product product, CancellationToken cancellationToken)
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

        await _decorated.DeleteAsync(product, cancellationToken);
    }

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken? cancellationToken)
    {
        return await _decorated.GetAllAsync(cancellationToken);
    }

    public async Task<IEnumerable<Product>> GetPaginatedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await _decorated.GetPaginatedAsync(pageNumber, pageSize, cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var key = $"productId-{id}";

        string? cashedMember = await _distributedCache.GetStringAsync(
            key,
            cancellationToken);

        if (string.IsNullOrEmpty(cashedMember))
        {
            var member = await _decorated.GetByIdAsync(id, cancellationToken);

            if (member is null)
            {
                return member!;
            }

            await _distributedCache.SetStringAsync(
                key,
                JsonConvert.SerializeObject(member),
                cancellationToken);

            return member;
        }

        return JsonConvert.DeserializeObject<Product>(cashedMember);
    }

    public async Task<int> GetCountAsync(CancellationToken cancellationToken)
    {
        return await _decorated.GetCountAsync(cancellationToken);
    }

    public async Task<string> UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        var key = $"productId-{product.Id}";

        var answer = await _decorated.UpdateAsync(product, cancellationToken);

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