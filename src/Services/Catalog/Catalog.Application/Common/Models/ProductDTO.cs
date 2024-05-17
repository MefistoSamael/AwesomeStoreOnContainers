namespace Catalog.Application.Common.Models
{
    public class ProductDTO
    {
        public required string Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required int Price { get; set; }

        public required int StockCount { get; set; }

        public required IEnumerable<CategoryDTO> ProductCatrgories { get; set; }
    }
}
