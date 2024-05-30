using Catalog.Application.Common.Models;
using MediatR;

namespace Catalog.Application.UseCases.Products.GetProductById;

public class GetProductByIdUseCase : IRequest<ProductDTO>
{
    public required string ProductId { get; set; }
}
