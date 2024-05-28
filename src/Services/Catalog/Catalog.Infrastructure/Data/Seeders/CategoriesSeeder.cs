using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Data.Seeders;

public class CategoriesSeeder
{

    public static void SeedCategories(ApplicationDbContext _context)
    {
        if (!_context.Categories.Any())
        {

            _context.Categories.AddRange(
            new Category
            {
                Id = "985E88A9-84B2-4458-B8F6-6D3B32AB12C8",
                Name = "Roofs"
            },
            new Category
            {
                Id = "94A9B343-E276-4BC4-8746-DF984CCD82C4",
                Name = "Fence"
            },
            new Category
            {
                Id = "819D8D10-D362-4AF7-B510-D423EA19FFCB",
                Name = "Metal tiles"
            },
            new Category
            {
                Id = "DBE0AFA6-1DE2-4CEC-B743-53E4F1B36B15",
                Name = "Slate"
            },
            new Category
            {
                Id = "57C88E0C-97F1-4D49-BD38-B860A2A332D1",
                Name = "Wood"
            });

            _context.SaveChanges();
        }
    }
}