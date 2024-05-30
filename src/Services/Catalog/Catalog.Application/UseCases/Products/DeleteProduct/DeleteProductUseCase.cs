using MediatR;

namespace Catalog.Application.UseCases.Products.DeleteProduct;

public class DeleteProductUseCase : IRequest
{
    public required string ProductId { get; set; }
}
