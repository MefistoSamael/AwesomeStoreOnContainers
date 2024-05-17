using Microsoft.AspNetCore.Http;

namespace Catalog.Application.UseCases.Product.CreateProduct
{
    public class CreateProductUseCase
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required int Price { get; set; }

        public required IFormFile Image { get; set; }

        public required int StockCount { get; set; }

        public required IEnumerable<string> Categories { get; set; }
    }
}
