using Catalog.Application.Common.Models;
using MediatR;

namespace Catalog.Application.UseCases.Product.GetProductById;

public class GetProductByIdUseCase : IRequest<ProductDTO>
{
    public required string ProductId { get; set; }
}
