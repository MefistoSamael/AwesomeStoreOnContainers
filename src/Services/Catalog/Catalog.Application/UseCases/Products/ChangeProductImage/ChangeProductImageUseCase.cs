using MediatR;
using Microsoft.AspNetCore.Http;

namespace Catalog.Application.UseCases.Products.ChangeProductImage;

public class ChangeProductImageUseCase : IRequest<string>
{
    public required string ProductId { get; set; }
    
    public required IFormFile Image { get; set; }
}
