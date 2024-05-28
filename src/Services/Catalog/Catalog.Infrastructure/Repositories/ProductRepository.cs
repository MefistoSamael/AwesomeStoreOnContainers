using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Threading;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepostitory
{
    private readonly IMongoCollection<Product> _products;

    private InsertOneOptions _insertOneOptions;
    private ReplaceOptions _updateOptions;
    private DeleteOptions _deleteOneOptions;

    public ProductRepository(IMongoCollection<Product> products)
    {
        _products = products;

        _insertOneOptions = new InsertOneOptions();
        _updateOptions = new ReplaceOptions();
        _deleteOneOptions = new DeleteOptions();
    }

    public async Task<string> CreateProductAsync(Product product, CancellationToken cancellationToken)
    {
        product.Id = Guid.NewGuid().ToString();

        await _products.InsertOneAsync(product, _insertOneOptions, cancellationToken);

        return product.Id;
    }

    public async Task<string> UpdateProductAsync(Product product, CancellationToken cancellationToken)
    {
        var idFilter = Builders<Product>.Filter.Eq(product => product.Id, product.Id);

        await _products.ReplaceOneAsync(idFilter, product, _updateOptions, cancellationToken);

        return product.Id;
    }

    public async Task DeleteProductAsync(Product product, CancellationToken cancellationToken)
    {
        var idFilter = Builders<Product>.Filter.Eq(product => product.Id, product.Id);

        await _products.DeleteOneAsync(idFilter, _deleteOneOptions, cancellationToken);
    }


    public Task<IEnumerable<Product>> GetPaginatedProductsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductByIdAsync(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetProductCountAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public async Task<string> AddToCategoriesAsync(Product product, IEnumerable<Category> categories, CancellationToken cancellationToken)
    {
        product.Categories.AddRange(categories);

        await UpdateProductAsync(product, cancellationToken);

        return product.Id;
    }

    public async Task<string> AddToCategoryAsync(Product product, Category category, CancellationToken cancellationToken)
    {
        product.Categories.Add(category);

        await UpdateProductAsync(product, cancellationToken);

        return product.Id;
    }

    public async Task<string> RemoveFromCategoriesAsync(Product product, IEnumerable<Category> categories, CancellationToken cancellationToken)
    {
        foreach (var category in categories) 
        {
            product.Categories.Remove(category);
        }

        await UpdateProductAsync(product, cancellationToken);

        return product.Id;
    }

    public async Task<string> RemoveFromCategoryAsync(Product product, Category category, CancellationToken cancellationToken)
    {
        product.Categories.Remove(category);

        await UpdateProductAsync(product, cancellationToken);

        return product.Id;
    }
}
