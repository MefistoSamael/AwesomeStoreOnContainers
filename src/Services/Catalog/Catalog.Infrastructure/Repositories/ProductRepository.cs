using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepostitory
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> CreateProductAsync(Product product, CancellationToken cancellationToken)
    {
        product.Id = Guid.NewGuid().ToString();

        await _context.Products.AddAsync(product, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return product.Id;
    }

    public async Task<string> UpdateProductAsync(Product product, CancellationToken cancellationToken)
    {
        _context.Products.Update(product);

        await _context.SaveChangesAsync(cancellationToken);

        return product.Id;
    }

    public Task DeleteProductAsync(Product product, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
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

        _context.Update(product);

        await _context.SaveChangesAsync(cancellationToken);

        return product.Id;
    }

    public async Task<string> AddToCategoryAsync(Product product, Category category, CancellationToken cancellationToken)
    {
        product.Categories.Add(category);

        _context.Update(product);

        await _context.SaveChangesAsync(cancellationToken);

        return product.Id;
    }

    public async Task<string> RemoveFromCategoriesAsync(Product product, IEnumerable<Category> categories, CancellationToken cancellationToken)
    {
        foreach (var category in categories) 
        {
            product.Categories.Remove(category);
        }

        _context.Update(product);

        await _context.SaveChangesAsync(cancellationToken);

        return product.Id;
    }

    public async Task<string> RemoveFromCategoryAsync(Product product, Category category, CancellationToken cancellationToken)
    {
        product.Categories.Remove(category);

        _context.Update(product);

        await _context.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}
