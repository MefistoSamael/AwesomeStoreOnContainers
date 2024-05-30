using MediatR;

namespace Catalog.Application.UseCases.Products.UpdateProduct;

public class UpdateProductUseCase : IRequest<string>
{
    public required string ProductId { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public required int Price { get; set; }
}
