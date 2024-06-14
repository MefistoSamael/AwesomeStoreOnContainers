using AutoMapper;
using Catalog.Application.Common.Models;
using Catalog.Domain.Abstractions;
using MediatR;

namespace Catalog.Application.UseCases.Products.GetPaginatedProducts;

public class GetPaginatedProductsInteractor : IRequestHandler<GetPaginatedProductsUseCase, PaginatedResult<ProductDTO>>
{
    private readonly IProductRepostitory _productRepostitory;
    private readonly IMapper _mapper;

    public GetPaginatedProductsInteractor(IProductRepostitory productRepostitory, IMapper mapper)
    {
        _productRepostitory = productRepostitory;
        _mapper = mapper;
    }

    public async Task<PaginatedResult<ProductDTO>> Handle(GetPaginatedProductsUseCase request, CancellationToken cancellationToken)
    {
        IEnumerable<Domain.Entities.Product> domainProducts = await _productRepostitory.GetPaginatedProductsAsync(request.PageNumber, request.PageSize, cancellationToken);

        IEnumerable<ProductDTO> products = _mapper.Map<IEnumerable<ProductDTO>>(domainProducts);

        int count = await _productRepostitory.GetProductCountAsync(cancellationToken);

        int totalPages = (int)Math.Ceiling(count / (double)request.PageSize);

        return new PaginatedResult<ProductDTO>
        {
            Collection = products,
            CurrentPage = request.PageNumber,
            PageSize = request.PageSize,
            TotalPageCount = totalPages,
            TotalItemCount = count,
        };
    }
}
