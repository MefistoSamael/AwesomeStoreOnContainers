using MediatR;
using Microsoft.AspNetCore.Http;

namespace Catalog.Application.UseCases.Products.ChangeProductImage;

public class ChangeProductImageUseCase : IRequest<string>
{
    required public string ProductId { get; set; }

    required public IFormFile Image { get; set; }
}
