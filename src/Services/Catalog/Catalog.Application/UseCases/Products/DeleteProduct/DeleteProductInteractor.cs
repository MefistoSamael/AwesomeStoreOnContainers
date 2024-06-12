using Catalog.Application.Services;
using Catalog.Domain.Abstractions;
using MediatR;

namespace Catalog.Application.UseCases.Products.DeleteProduct;

public class DeleteProductInteractor : IRequestHandler<DeleteProductUseCase>
{
    private readonly IProductRepostitory _productRepostitory;
    private readonly IImageService _imageService;

    public DeleteProductInteractor(IProductRepostitory productRepostitory, IImageService imageService)
    {
        _productRepostitory = productRepostitory;
        _imageService = imageService;
    }

    public async Task Handle(DeleteProductUseCase request, CancellationToken cancellationToken)
    {
        var product = await _productRepostitory.GetProductByIdAsync(request.ProductId, cancellationToken);

        if (product is null)
        {
            throw new KeyNotFoundException("product with specified id wasn't found");
        }

        _imageService.DeleteImage(product);
        await _productRepostitory.DeleteProductAsync(product, cancellationToken);
    }
}
