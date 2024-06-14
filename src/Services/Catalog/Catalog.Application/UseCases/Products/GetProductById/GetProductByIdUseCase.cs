using Catalog.Application.Common.Models;
using MediatR;

namespace Catalog.Application.UseCases.Products.GetProductById;

public class GetProductByIdUseCase : IRequest<ProductDTO>
{
    required public string ProductId { get; set; }
}
