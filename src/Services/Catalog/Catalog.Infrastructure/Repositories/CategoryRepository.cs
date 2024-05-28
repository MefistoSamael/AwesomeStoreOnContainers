using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
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
        return await _context.Categories.CountAsync(cancellationToken);
    }

    public async Task<Category?> GetCategoryByIdAsync(string id, CancellationToken cancellationToken)
    {
        return await _context.Categories.SingleOrDefaultAsync(category => category.Id == id, cancellationToken);
    }

    public async Task<Category?> GetCategoryByNameAsync(string categoryName, CancellationToken cancellationToken)
    {
        return await _context.Categories.SingleOrDefaultAsync(category => category.Name == categoryName, cancellationToken);
    }

    public async Task<IEnumerable<Category>> GetPaginatedCategoriesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await _context.Categories
            .OrderBy(category => category.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
}
