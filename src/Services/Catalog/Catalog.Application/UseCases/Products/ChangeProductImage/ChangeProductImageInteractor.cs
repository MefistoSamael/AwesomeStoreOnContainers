using Catalog.Application.Services;
using Catalog.Domain.Abstractions;
using MediatR;

namespace Catalog.Application.UseCases.Products.ChangeProductImage;

public class ChangeProductImageInteractor : IRequestHandler<ChangeProductImageUseCase, string>
{
    private readonly IImageService _imageService;
    private readonly IProductRepostitory _productRepository;

    public ChangeProductImageInteractor(IImageService imageService, IProductRepostitory productRepository)
    {
        _imageService = imageService;
        _productRepository = productRepository;
    }

    public async Task<string> Handle(ChangeProductImageUseCase request, CancellationToken cancellationToken)
    {
        Domain.Entities.Product product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken)
            ?? throw new KeyNotFoundException("product with specified id wasn't found");

        await _imageService.SaveImageAsync(request.Image, product, cancellationToken);

        return product.Id;
    }
}
