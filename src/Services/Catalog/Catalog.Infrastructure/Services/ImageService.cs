using Catalog.Application.Services;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Catalog.Infrastructure.Services;

public class ImageService : IImageService
{
    private readonly IProductRepostitory _productRepostitory;
    private WWWRootOptions _options;

    public ImageService(IProductRepostitory productRepostitory, IOptions<WWWRootOptions> options)
    {
        _productRepostitory = productRepostitory;
        _options = options.Value;
    }

    public async Task<Product> SaveImageAsync(IFormFile image, Product product, CancellationToken cancellationToken)
    {
        var imageFolder = Path.Combine(_options.WebRootPath, "Images");

        await DeleteImageAsync(imageFolder, product);

        var extension = Path.GetExtension(image.FileName);
        var fileName = Path.ChangeExtension(Path.GetRandomFileName(), extension);
        
        var filePath = Path.Combine(imageFolder, fileName);

        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
        {
            await image.CopyToAsync(fileStream, cancellationToken);
        }

        product.PictureUri = $"{_options.Host}/Images/{fileName}";
        product.PictureFileName = extension;

        await _productRepostitory.UpdateProductAsync(product, cancellationToken);

        return product;
    }

    private Task DeleteImageAsync(string imageFolder, Product product)
    {
        throw new NotImplementedException();
    }
}
