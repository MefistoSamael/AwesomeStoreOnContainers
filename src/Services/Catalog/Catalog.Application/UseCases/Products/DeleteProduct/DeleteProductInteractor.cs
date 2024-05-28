using Catalog.Domain.Abstractions;
using MediatR;

namespace Catalog.Application.UseCases.Product.DeleteProduct;

public class DeleteProductInteractor : IRequestHandler<DeleteProductUseCase>
{
    private readonly IProductRepostitory _productRepostitory;

    public DeleteProductInteractor(IProductRepostitory productRepostitory)
    {
        _productRepostitory = productRepostitory;
    }

    public async Task Handle(DeleteProductUseCase request, CancellationToken cancellationToken)
    {
        var product = await _productRepostitory.GetProductByIdAsync(request.ProductId, cancellationToken);

        if (product is null)
        {
            return;
        }

        await _productRepostitory.DeleteProductAsync(product, cancellationToken);
    }
}
