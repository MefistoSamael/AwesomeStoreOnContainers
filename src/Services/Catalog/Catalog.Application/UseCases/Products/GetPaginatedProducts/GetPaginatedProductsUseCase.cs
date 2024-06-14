using Catalog.Application.Common.Models;
using MediatR;

namespace Catalog.Application.UseCases.Products.GetPaginatedProducts;

public class GetPaginatedProductsUseCase : IRequest<PaginatedResult<ProductDTO>>
{
    required public int PageNumber { get; set; }

    required public int PageSize { get; set; }
}
