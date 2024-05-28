using Catalog.Domain.Abstractions;
using MediatR;

namespace Catalog.Application.UseCases.Product.UpdateProduct;

public class UpdateProductInteractor : IRequestHandler<UpdateProductUseCase, string>
{
    private readonly IProductRepostitory _productRepostitory;

    public UpdateProductInteractor(IProductRepostitory productRepostitory)
    {
        _productRepostitory = productRepostitory;
    }

    public async Task<string> Handle(UpdateProductUseCase request, CancellationToken cancellationToken)
    {
        var product = await _productRepostitory.GetProductByIdAsync(request.ProductId, cancellationToken);

        if (product is null)
        {
            throw new KeyNotFoundException($"product with {request.ProductId} id not found");
        }

        product.Price = request.Price;
        product.Description = request.Description;
        product.Name = request.Name;

        await _productRepostitory.UpdateProductAsync(product, cancellationToken);

        return product.Id;
    }
}
