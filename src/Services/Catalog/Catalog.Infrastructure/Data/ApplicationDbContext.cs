using Catalog.Domain.Entities;
using Catalog.Infrastructure.Data.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Category> _categories { get; init; }
    public DbSet<Product> _products { get; init; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
