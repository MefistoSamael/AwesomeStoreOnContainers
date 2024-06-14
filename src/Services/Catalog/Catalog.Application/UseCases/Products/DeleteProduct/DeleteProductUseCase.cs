using MediatR;

namespace Catalog.Application.UseCases.Products.DeleteProduct;

public class DeleteProductUseCase : IRequest
{
    required public string ProductId { get; set; }
}
