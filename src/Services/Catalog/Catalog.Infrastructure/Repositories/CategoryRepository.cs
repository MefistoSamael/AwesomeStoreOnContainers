using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IMongoCollection<Category> _categories;
    
    private EstimatedDocumentCountOptions _estimatedDocumentCountOptions;
    
    public CategoryRepository(IMongoCollection<Category> categories)
    {
        _categories = categories;
        _estimatedDocumentCountOptions = new EstimatedDocumentCountOptions();
    }

    public Task<string> CreateCategoryAsync(Category product, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryAsync(Category product, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> UpdateCategoryAsync(Category product, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public async Task<int> GetCategoriesCountAsync(CancellationToken cancellationToken)
    {
                    return (int)await _categories.EstimatedDocumentCountAsync(_estimatedDocumentCountOptions, cancellationToken);
    }

    public async Task<Category?> GetCategoryByIdAsync(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<Category>.Filter.Eq(category => category.Id, id);

        return await (await _categories.FindAsync(filter, cancellationToken: cancellationToken)).FirstOrDefaultAsync();
    }

    public async Task<Category?> GetCategoryByNameAsync(string categoryName, CancellationToken cancellationToken)
    {
        var filter = Builders<Category>.Filter.Eq(category => category.Name, categoryName);

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
}
