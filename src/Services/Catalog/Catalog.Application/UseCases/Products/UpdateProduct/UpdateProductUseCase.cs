using MediatR;

namespace Catalog.Application.UseCases.Products.UpdateProduct;

public class UpdateProductUseCase : IRequest<string>
{
    required public string ProductId { get; set; }

    required public string Name { get; set; }

    required public string Description { get; set; }

    required public int Price { get; set; }
}
