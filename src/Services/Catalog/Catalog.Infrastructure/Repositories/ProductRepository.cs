﻿using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

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


    public async Task<IEnumerable<Product>> GetPaginatedProductsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await _products.Find(filter => true)
            .SortBy(category => category.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<Product> GetProductByIdAsync(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<Product>.Filter.Eq(product => product.Id, id);

        return await (await _products.FindAsync(filter, cancellationToken: cancellationToken)).FirstOrDefaultAsync();
    }

    public async Task<int> GetProductCountAsync(CancellationToken cancellationToken)
    {
        return (int)await _products.EstimatedDocumentCountAsync(cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken? cancellationToken)
    {
        var notNullableCancellationToken = cancellationToken ?? default;

        var filter = Builders<Product>.Filter.Empty;
        return  await (await _products.FindAsync<Product>(filter, cancellationToken: notNullableCancellationToken))
            .ToListAsync(cancellationToken: notNullableCancellationToken);
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

    public async Task AddStockCount(Product product, int restockAmount)
    {
        var filter = Builders<Product>.Filter.Where(prod => prod.Id == product.Id);

        var update = Builders<Product>.Update.Inc(product => product.StockCount, restockAmount);

        await _products.UpdateManyAsync(filter, update);
    }
}