using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IMongoCollection<Category> _categories;
    private readonly IMongoCollection<Product> _products;


    private InsertOneOptions _insertOneOptions;
    private EstimatedDocumentCountOptions _estimatedDocumentCountOptions;
    private DeleteOptions _deleteOneOptions;

    public CategoryRepository(IMongoCollection<Category> categories, IMongoCollection<Product> products)
    {
        _categories = categories;
        _estimatedDocumentCountOptions = new EstimatedDocumentCountOptions();
        _products = products;
        _insertOneOptions = new InsertOneOptions();
        _deleteOneOptions = new DeleteOptions();
    }

    public async Task<string> CreateCategoryAsync(Category category, CancellationToken cancellationToken)
    {
        category.Id = Guid.NewGuid().ToString();

        await _categories.InsertOneAsync(category, _insertOneOptions, cancellationToken);

        return category.Id;

    }

    public async Task DeleteCategoryAsync(Category category, CancellationToken cancellationToken)
    {
        var idFilter = Builders<Category>.Filter.Eq(category => category.Id, category.Id);

        await _categories.DeleteOneAsync(idFilter, _deleteOneOptions, cancellationToken);
    }

    public async Task<string> UpdateCategoryAsync(Category category, CancellationToken cancellationToken)
    {
        var filter = Builders<Product>.Filter.ElemMatch(p => p.Categories, c => c.Id == category.Id);

        var update = Builders<Product>.Update
        .Set("Categories.$.Name", category.Name) 
        .Set("Categories.$.NormalizedName", category.NormalizedName);

        await _products.UpdateManyAsync(filter, update, cancellationToken: cancellationToken);

        return category.Id;
    }


    public async Task<int> GetCategoriesCountAsync(CancellationToken cancellationToken)
    {
        return (int) await _categories.EstimatedDocumentCountAsync(_estimatedDocumentCountOptions, cancellationToken);
    }

    public async Task<Category?> GetCategoryByIdAsync(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<Category>.Filter.Eq(category => category.Id, id);

        return await (await _categories.FindAsync(filter, cancellationToken: cancellationToken)).FirstOrDefaultAsync();
    }

    public async Task<Category?> GetCategoryByNameAsync(string categoryName, CancellationToken cancellationToken)
    {
        var filter = Builders<Category>.Filter.Eq(category => category.NormalizedName, categoryName.ToUpper());

        return await (await _categories.FindAsync(filter, cancellationToken: cancellationToken)).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Category>> GetPaginatedCategoriesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await _categories.Find(filter => true)
            .SortBy(category => category.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> HasProductsAsync(Category category, CancellationToken cancellationToken)
    {
        var filter = Builders<Product>.Filter.ElemMatch(p => p.Categories, c => c.Id == category.Id);

        return await _products.Find(filter).AnyAsync(cancellationToken);
    }
}
