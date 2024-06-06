﻿using Catalog.Application.Common.Models;
using MediatR;

namespace Catalog.Application.UseCases.Products.GetPaginatedProducts;

public class GetPaginatedProductsUseCase : IRequest<PaginatedResult<ProductDTO>>
{
    public required int PageNumber { get; set; }
    public required int PageSize { get; set; }
}