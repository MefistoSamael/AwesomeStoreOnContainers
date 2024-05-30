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
    private string imageFolder = "";

    public ImageService(IProductRepostitory productRepostitory, IOptions<WWWRootOptions> options)
    {
        _productRepostitory = productRepostitory;
        _options = options.Value;
        imageFolder = Path.Combine(_options.WebRootPath, "Images");
    }

    public async Task<Product> SaveImageAsync(IFormFile image, Product product, CancellationToken cancellationToken)
    {
        DeleteImage(product);

        var extension = Path.GetExtension(image.FileName);
        var fileName = Path.ChangeExtension(Path.GetRandomFileName(), extension);
        
        var filePath = Path.Combine(imageFolder, fileName);

        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
        {
            await image.CopyToAsync(fileStream, cancellationToken);
        }

        product.ImageUri = $"{_options.Host}/Images/{fileName}";
        product.ImageFileName = extension;

        await _productRepostitory.UpdateProductAsync(product, cancellationToken);

        return product;
    }

    public void DeleteImage(Product product)
    {
        if (!string.IsNullOrEmpty(product.ImageUri))
        {
            var prevImage = Path.Combine(imageFolder, Path.GetFileName(product.ImageUri));
            File.Delete(prevImage);
        }
    }
}
