namespace Catalog.Domain.Entities
{
    public class Product
    {
        public required string Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required int Price { get; set; }

        public string? PictureFileName { get; set; }
        
        public string? PictureUri { get; set; }
        
        public required int StockCount { get; set; }


    }
}
