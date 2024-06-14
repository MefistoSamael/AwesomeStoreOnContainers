using Catalog.Domain.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.Seeders;

public class CategoriesSeeder
{
    public static void SeedCategories(IMongoCollection<Category> categories)
    {
        if (categories.EstimatedDocumentCount() == 0)
        {
            categories.InsertMany(new List<Category>
            {
                new ()
                {
                Id = "985E88A9-84B2-4458-B8F6-6D3B32AB12C8",
                Name = "Roofs",
                NormalizedName = "Roofs".ToUpper(),
                },
                new ()
                {
                Id = "94A9B343-E276-4BC4-8746-DF984CCD82C4",
                Name = "Fence",
                NormalizedName = "Fence".ToUpper(),
                },
                new ()
                {
                Id = "819D8D10-D362-4AF7-B510-D423EA19FFCB",
                Name = "Metal tiles",
                NormalizedName = "Metal tiles".ToUpper(),
                },
                new ()
                {
                Id = "DBE0AFA6-1DE2-4CEC-B743-53E4F1B36B15",
                Name = "Slate",
                NormalizedName = "Slate".ToUpper(),
                },
                new ()
                {
                Id = "57C88E0C-97F1-4D49-BD38-B860A2A332D1",
                Name = "Wood",
                NormalizedName = "Wood".ToUpper(),
                },
            });
        }
    }
}