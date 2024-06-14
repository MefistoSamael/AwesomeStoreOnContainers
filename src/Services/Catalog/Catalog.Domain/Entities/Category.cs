namespace Catalog.Domain.Entities;

public class Category
{
    required public string Id { get; set; }

    required public string Name { get; set; }

    required public string NormalizedName { get; set; }
}
