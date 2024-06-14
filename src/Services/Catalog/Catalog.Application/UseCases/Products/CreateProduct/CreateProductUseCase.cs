using MediatR;
using Microsoft.AspNetCore.Http;

namespace Catalog.Application.UseCases.Products.CreateProduct;

public class CreateProductUseCase : IRequest<string>
{
    required public string Name { get; set; }

    required public string Description { get; set; }

    required public int Price { get; set; }

    required public IFormFile Image { get; set; }

    required public int StockCount { get; set; }

    required public IEnumerable<string> Categories { get; set; }
}
