using MediatR;

namespace Catalog.Application.UseCases.Product.DeleteProduct;

public class DeleteProductUseCase : IRequest
{
    public required string ProductId { get; set; }
}
