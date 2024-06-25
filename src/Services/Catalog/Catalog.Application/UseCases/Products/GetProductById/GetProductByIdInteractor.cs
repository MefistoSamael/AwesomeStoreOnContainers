using AutoMapper;
using Catalog.Application.Common.Models;
using Catalog.Domain.Abstractions;
using MediatR;

namespace Catalog.Application.UseCases.Products.GetProductById;

public class GetProductByIdInteractor : IRequestHandler<GetProductByIdUseCase, ProductDTO>
{
    private readonly IProductRepostitory _productRepostitory;
    private readonly IMapper _mapper;

    public GetProductByIdInteractor(IProductRepostitory productRepostitory, IMapper mapper)
    {
        _productRepostitory = productRepostitory;
        _mapper = mapper;
    }

    public async Task<ProductDTO> Handle(GetProductByIdUseCase request, CancellationToken cancellationToken)
    {
        Domain.Entities.Product? product = await _productRepostitory.GetByIdAsync(request.ProductId, cancellationToken);

        return product is null
            ? throw new KeyNotFoundException($"product with {request.ProductId} id not found")
            : _mapper.Map<ProductDTO>(product);
    }
}
